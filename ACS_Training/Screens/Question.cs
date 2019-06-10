using System;
using System.Collections.Generic;
using ACS_Training.Classes;

namespace ACS_Training.Screens
{
    internal class Question
    {
        private Topic topic;

        public Question(Topic topic)
        {
            this.topic = topic;
        }

        public string questionDescription { get; set; }
        public string questionText { get; set; }
        public List<Option> options { get; set; }

        public Question getQuestion()
        {
            var random = new Random();
            List<Option> options = new List<Option>();

            SubTopic correctAnswerSubTopic = topic.subTopics[random.Next(topic.subTopics.Count)];
            Option correctOption = new Option() { optionText = correctAnswerSubTopic.name, status = true };
            options.Add(correctOption);
            this.questionText = correctAnswerSubTopic.points[random.Next(correctAnswerSubTopic.points.Count)];

            topic.subTopics.Remove(correctAnswerSubTopic);

            Option incorrectOption = new Option { optionText = topic.subTopics[random.Next(topic.subTopics.Count)].name, status = false };
            options.Add(incorrectOption);
            this.options = options;

            this.questionDescription = "For the given statememt, \nPlease choose the subtopic it belongs to ";
            return this;

        }
    }
}