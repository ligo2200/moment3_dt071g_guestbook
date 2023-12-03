/*
 * Code written by Linda Götenmark, ht 2023
 * ligo2200@student.miun.se
 * MidSweden University, course DT071G
 * moment 3 - guestbook
 * Class GuestBookEntry
 */

using System;



namespace moment3
{
     public class GuestBookEntry
    {
        private string owner = "";
        private string text = "";

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        //constructor
        public GuestBookEntry(string owner, string text)
        {
            Owner = owner;
            Text = text;
        }

    }
}
