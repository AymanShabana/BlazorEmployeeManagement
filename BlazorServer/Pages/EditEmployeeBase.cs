using AutoMapper;
using BlazorServer.Models;
using BlazorServer.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Razor.CustomComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BlazorServer.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public string HeaderText { get; set; }
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        public List<Department> Departments { get; set; } = new List<Department>();
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected ConfirmBase DeleteDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(Id != 0)
            {
                HeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(Id);
            }
            else
            {
                HeaderText = "Create Employee";

                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBrith = DateTime.Now,
                    PhotoPath = "images/question.jpg"
                };
            }
            Departments = (await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);
 
        }
        protected async Task HandleValidSubmit() 
        {
            Mapper.Map(EditEmployeeModel,Employee);
            Employee result = null;
            if(Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
        protected async Task DeleteButtonClicked()
        {
            DeleteDialog.Show();
        }
        protected async Task ConfirmationChoiceSelected(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
            }

        }
    }
}
