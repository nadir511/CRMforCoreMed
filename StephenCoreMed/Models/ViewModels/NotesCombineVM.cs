using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class NotesCombineVM
    {
        public List<NotesVM> ListnotesVMs { get; set; }
        public NotesVM NotesVM { get; set; }
    }
}