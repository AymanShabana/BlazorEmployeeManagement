using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages
{
    public class DataBindingBase : ComponentBase
    {
        public string Name { get; set; } = "Ayman";
        public string Gender { get; set; } = "Male";
        public string Colour { get; set; } = "background-color:white";
        public string Text { get; set; } = "";


    }
}
