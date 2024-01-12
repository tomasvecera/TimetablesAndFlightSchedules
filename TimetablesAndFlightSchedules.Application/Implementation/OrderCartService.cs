using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Application.Implementation
{
    public class OrderCartService : IOrderCartService
    {
        const string totalPriceString = "TotalPrice";
        const string orderItemsString = "OrderItems";


        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public OrderCartService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }


        public double AddOrderItemsToSession(int? routeInstanceId, ISession session)
        {
            //get total price from session
            double totalPrice = session.GetDouble(totalPriceString).GetValueOrDefault();


            //get route instance which should be added to cart/session
            RouteInstance? routeInstance = _timetablesAndFlightSchedulesDbContext.RouteInstances.FirstOrDefault(rout => rout.Id == routeInstanceId);
            Route? route = _timetablesAndFlightSchedulesDbContext.Routes.FirstOrDefault(r => r.Id == routeInstance.RouteID);

            if (routeInstance != null)
            {
                //get list of order items from session
                List<OrderItem> orderItems = session.GetObject<List<OrderItem>>(orderItemsString);
                OrderItem? orderItemInSession = null;
                //if the list is already in the session, find the order item with the RouteInstanceID, otherwise, create new list
                if (orderItems != null)
                    orderItemInSession = orderItems.Find(oi => oi.RouteInstanceID == routeInstance.Id);
                else
                    orderItems = new List<OrderItem>();


                //if there is order item with RouteInstanceID, increase amount and price, otherwise, add new OrderItem
                if (orderItemInSession != null)
                {
                    ++orderItemInSession.Amount;
                    orderItemInSession.Price += route.PriceOfTicket;
                }
                else
                {
                    //create order item with connected route instance and add it to the list
                    OrderItem orderItem = new OrderItem()
                    {
                        RouteInstanceID = routeInstance.Id,
                        RouteInstance = routeInstance,
                        Amount = 1,
                        Price = route.PriceOfTicket
                    };

                    orderItems.Add(orderItem);
                }

                //set the list to the session
                session.SetObject(orderItemsString, orderItems);

                //increase the total price and set it to the session
                totalPrice += route.PriceOfTicket;
                session.SetDouble(totalPriceString, totalPrice);
            }

            //return total price
            return totalPrice;
        }


        public bool ApproveOrderInSession(int userId, ISession session)
        {
            //get order items from the session
            List<OrderItem> orderItems = session.GetObject<List<OrderItem>>(orderItemsString);
            if (orderItems != null)
            {

                //get total price from session
                double totalPrice = session.GetDouble(totalPriceString).GetValueOrDefault();

                //reference to the product must be null; otherwise, it tries to add it to the database again
                orderItems.ForEach(orderItem => orderItem.RouteInstance = null);

                ////alternate option for the problem above
                //double totalPrice = 0;
                //foreach (OrderItem orderItem in orderItems)
                //{
                //    //recalculate total price (just to be sure; the total price is in the session too and the value should be same)
                //    totalPrice += orderItem.Product.Price * orderItem.Amount;
                //    //reference to the product must be null; otherwise, it tries to add it to the database again
                //    orderItem.Product = null;
                //}


                //create new order and connect it with the list of the order items
                Order order = new Order()
                {
                    OrderNumber = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                    TotalPrice = totalPrice,
                    OrderItems = orderItems,
                    UserId = userId
                };



                //We can add just the order; connected order items will be added automatically to the database.
                _timetablesAndFlightSchedulesDbContext.Add(order);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();


                //remove the informations from the session
                session.Remove(orderItemsString);
                session.Remove(totalPriceString);


                //success
                return true;

            }


            //failure
            return false;
        }

    }
}