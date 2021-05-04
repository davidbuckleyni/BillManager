using BillManager.Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillManager.Dal.Models
{
   public class BillTypes : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Order { get; set; }
        public string Image { get; set; }
        public bool Selected { get; set; }


        private string _backgroundColor;
        public string BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        private string _textColor;
        public string textColor
        {
            get => _textColor;
            set => SetProperty(ref _textColor, value);
        }
    }
}
