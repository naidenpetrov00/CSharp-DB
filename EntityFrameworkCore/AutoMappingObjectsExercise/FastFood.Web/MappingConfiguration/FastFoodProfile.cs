﻿namespace FastFood.Web.MappingConfiguration
{
	using AutoMapper;
	using FastFood.Web.ViewModels.Categories;
	using FastFood.Web.ViewModels.Employees;
	using FastFood.Web.ViewModels.Items;
	using FastFood.Web.ViewModels.Orders;
	using Microsoft.EntityFrameworkCore.Internal;
	using Models;

	using ViewModels.Positions;

	public class FastFoodProfile : Profile
	{
		public FastFoodProfile()
		{
			//Positions
			this.CreateMap<CreatePositionInputModel, Position>()
				.ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

			this.CreateMap<Position, PositionsAllViewModel>()
				.ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

			this.CreateMap<Position, RegisterEmployeeViewModel>()
				.ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id))
				.ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

			//Employee
			this.CreateMap<RegisterEmployeeInputModel, Employee>();

			this.CreateMap<Employee, EmployeesAllViewModel>()
				.ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

			//Category
			this.CreateMap<CreateCategoryInputModel, Category>()
				.ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

			this.CreateMap<Category, CategoryAllViewModel>();

			//Item
			this.CreateMap<CreateItemInputModel, Item>();

			this.CreateMap<Category, CreateItemViewModel>()
				.ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id))
				.ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

			this.CreateMap<Item, ItemsAllViewModels>()
				.ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

			//Orders
			//this.CreateMap<Item, CreateOrderViewModel>();
			this.CreateMap<CreateOrderInputModel, Order>();

			this.CreateMap<CreateOrderInputModel, Item>()
				.ForMember(x => x.Id, y => y.MapFrom(s => s.ItemId));

			this.CreateMap<Order, OrderAllViewModel>()
				.ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
				.ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name))
				.ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString()));
		}
	}
}
