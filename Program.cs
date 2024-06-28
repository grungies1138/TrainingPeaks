using System.ComponentModel.Design;
using System.Text.Json;
using System.Linq;
using TrainingPeaks.Data;
using TrainingPeaks.Models;

// Load data
var users = ImportData.ImportDataFile<User>("Data/users.json");
var exercises = ImportData.ImportDataFile<Exercise>("Data/exercises.json");
var workouts = ImportData.ImportDataFile<Workout>("Data/workouts.json");


/** Candidate TODO: Write code to answer questions **/


// In total, how many pounds have these athletes Bench Pressed?
var benchPress = exercises
                    .Where(exercise => exercise.Title == "Bench Press")
                    .Select(exercise => exercise.Id)
                    .FirstOrDefault();

var answerOne = workouts
            .SelectMany(workout => workout.Blocks)
            .Where(block => block.ExerciseId == benchPress)
            .SelectMany(block => block.Sets)
            .Where(set => set.Weight.HasValue)
            .Sum(set => set.Weight.Value);

// How many pounds did Barry Moore Back Squat in 2016?
var backSquat = exercises
                    .Where(exercise => exercise.Title == "Back Squat")
                    .Select(exercise => exercise.Id)
                    .FirstOrDefault();

var barry = users
                    .Where(user => user.FirstName == "Barry" && user.LastName == "Moore")
                    .Select(user => user.Id)
                    .FirstOrDefault();

var answerTwo = workouts.Where(workout => workout.UserId == barry && workout.Completed.Year == 2016)
            .SelectMany(workout => workout.Blocks)
            .Where(block => block.ExerciseId == backSquat)
            .SelectMany(block => block.Sets)
            .Where(set => set.Weight.HasValue)
            .Sum(set => set.Weight.Value);

// In what month of 2017 did Barry Moore Back Squat the most total weight?
var answerThree = workouts
                    .Where(workout => workout.Completed.Year == 2017 && workout.UserId == barry)    
                    .SelectMany(workout => workout.Blocks
                                                    .OrderByDescending(block => block.Sets.Max(set => set.Weight)), 
                        (workout, block) => workout.Completed.ToString("MMMM")).First();


// What is Abby Smith's Bench Press PR weight?
// (PR defined as the most the person has ever lifted for that exercise, regardless of reps performed.)
var abby = users.Where(user => user.FirstName == "Abby" && user.LastName == "Smith")
                .Select(user => user.Id)
                .FirstOrDefault();

var answerFour = workouts
                    .Where(workout => workout.UserId == abby)
                    .SelectMany(workout => workout.Blocks)
                    .Where(block => block.ExerciseId == benchPress)
                    .Select(block => block.Sets.Max(set => set.Weight))
                    .FirstOrDefault();

var results = new Dictionary<string, string> {
    {"Q1", answerOne.ToString()},
    {"Q2", answerTwo.ToString()},
    {"Q3", answerThree},
    {"Q4", answerFour.ToString()}
};

Console.WriteLine(JsonSerializer.Serialize(results));
