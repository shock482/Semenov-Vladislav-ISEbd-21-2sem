﻿using FlowerShopModel;
using FlowerShopService.DataFromUser;
using FlowerShopService.Interfaces;
using FlowerShopService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerShopService.ImplementationsList
{
    public class MainServiceList : InterfaceMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ModelBookingView> getList()
        {
            List<ModelBookingView> result = new List<ModelBookingView>();
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                string CustomerFullName = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].ID == source.Bookings[i].CustomerID)
                    {
                        CustomerFullName = source.Customers[j].CustomerFullName;
                        break;
                    }
                }
                string OutputName = string.Empty;
                for (int j = 0; j < source.Outputs.Count; ++j)
                {
                    if (source.Outputs[j].ID == source.Bookings[i].OutputID)
                    {
                        OutputName = source.Outputs[j].OutputName;
                        break;
                    }
                }
                string executorFullName = string.Empty;
                if (source.Bookings[i].ExecutorID.HasValue)
                {
                    for (int j = 0; j < source.Executors.Count; ++j)
                    {
                        if (source.Executors[j].ID == source.Bookings[i].ExecutorID.Value)
                        {
                            executorFullName = source.Executors[j].ExecutorFullName;
                            break;
                        }
                    }
                }
                result.Add(new ModelBookingView
                {
                    ID = source.Bookings[i].ID,
                    CustomerID = source.Bookings[i].CustomerID,
                    CustomerFullName = CustomerFullName,
                    OutputID = source.Bookings[i].OutputID,
                    OutputName = OutputName,
                    ExecutorID = source.Bookings[i].ExecutorID,
                    ExecutorName = executorFullName,
                    Count = source.Bookings[i].Count,
                    Summa = source.Bookings[i].Summa,
                    DateOfCreate = source.Bookings[i].DateOfCreate.ToLongDateString(),
                    DateOfImplement = source.Bookings[i].DateOfImplement?.ToLongDateString(),
                    Status = source.Bookings[i].Status.ToString()
                });
            }
            return result;
        }

        public void createOrder(BoundBookingModel model)
        {
            int maxID = 0;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].ID > maxID)
                    maxID = source.Customers[i].ID;
            }
            source.Bookings.Add(new Booking
            {
                ID = maxID + 1,
                CustomerID = model.CustomerID,
                OutputID = model.OutputID,
                DateOfCreate = DateTime.Now,
                Count = model.Count,
                Summa = model.Summa,
                Status = StatusOfBooking.Принятый
            });
        }

        public void takeOrderInWork(BoundBookingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].ID == model.ID)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                throw new Exception("Элемент не найден");
            for (int i = 0; i < source.OutputElements.Count; ++i)
            {
                if (source.OutputElements[i].OutputID == source.Bookings[index].OutputID)
                {
                    int countOnStocks = 0;
                    for (int j = 0; j < source.ReserveElements.Count; ++j)
                    {
                        if (source.ReserveElements[j].ElementID == source.OutputElements[i].ElementID)
                            countOnStocks += source.ReserveElements[j].Count;
                    }
                    if (countOnStocks < source.OutputElements[i].Count * source.Bookings[index].Count)
                    {
                        for (int j = 0; j < source.Elements.Count; ++j)
                        {
                            if (source.Elements[j].ID == source.OutputElements[i].ElementID)
                                throw new Exception("Не достаточно компонента " + source.Elements[j].ElementName +
                                    " требуется " + source.OutputElements[i].Count + ", в наличии " + countOnStocks);
                        }
                    }
                }
            }
            for (int i = 0; i < source.OutputElements.Count; ++i)
            {
                if (source.OutputElements[i].OutputID == source.Bookings[index].OutputID)
                {
                    int countOnStocks = source.OutputElements[i].Count * source.Bookings[index].Count;
                    for (int j = 0; j < source.ReserveElements.Count; ++j)
                    {
                        if (source.ReserveElements[j].ElementID == source.OutputElements[i].ElementID)
                        {
                            if (source.ReserveElements[j].Count >= countOnStocks)
                            {
                                source.ReserveElements[j].Count -= countOnStocks;
                                break;
                            }
                            else
                            {
                                countOnStocks -= source.ReserveElements[j].Count;
                                source.ReserveElements[j].Count = 0;
                            }
                        }
                    }
                }
            }
            source.Bookings[index].ExecutorID = model.ExecutorID;
            source.Bookings[index].DateOfImplement = DateTime.Now;
            source.Bookings[index].Status = StatusOfBooking.Выполняемый;
        }

        public void finishOrder(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Customers[i].ID == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                throw new Exception("Элемент не найден");
            source.Bookings[index].Status = StatusOfBooking.Готов;
        }

        public void payOrder(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Customers[i].ID == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                throw new Exception("Элемент не найден");
            source.Bookings[index].Status = StatusOfBooking.Оплаченный;
        }

        public void putComponentOnReserve(BoundResElementModel model)
        {
            int maxID = 0;
            for (int i = 0; i < source.ReserveElements.Count; ++i)
            {
                if (source.ReserveElements[i].ReserveID == model.ReserveID &&
                    source.ReserveElements[i].ElementID == model.ElementID)
                {
                    source.ReserveElements[i].Count += model.Count;
                    return;
                }
                if (source.ReserveElements[i].ID > maxID)
                    maxID = source.ReserveElements[i].ID;
            }
            source.ReserveElements.Add(new ReserveElement
            {
                ID = ++maxID,
                ReserveID = model.ReserveID,
                ElementID = model.ElementID,
                Count = model.Count
            });
        }
    }
}
