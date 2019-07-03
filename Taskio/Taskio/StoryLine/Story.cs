using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taskio.Interface;
using Xamarin.Forms;

namespace Taskio.StoryLine
{
	public class Story : IStory
	{
        public string Title { get; set; } = "Chapter 1";
        public string Detail { get; set; } = @"It was a cold december night. When the wind was howling and the dogs were barking. All I could see was the naked trees dancing outside 
the window of my tiny apartment.";
        public string Color { get; set; } = "Red";
        public int PlaceNumber { get; set; } = 1;
    }
}