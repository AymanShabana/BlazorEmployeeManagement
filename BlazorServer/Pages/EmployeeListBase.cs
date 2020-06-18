using BlazorServer.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Employee> Employees { get; set; }
        public int SelectedCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeService.GetEmployees();
        }
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedCount++;
            }
            else
            {
                SelectedCount--;
            }
        }
        protected async Task EmployeeDeleted()
        {
            Employees = await EmployeeService.GetEmployees();
        }
    }
}
