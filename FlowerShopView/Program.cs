﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShopService;
using FlowerShopService.ImplementationsDB;
using FlowerShopService.ImplementationsList;
using FlowerShopService.Interfaces;
using Unity;
using Unity.Lifetime;

namespace FlowerShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<InterfaceCustomerService, CustomerServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<InterfaceComponentService, ElementServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<InterfaceExecutorService, ExecutorServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<InterfaceOutputService, OutputServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<InterfaceReserveService, ReserveServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<InterfaceMainService, MainServiceBD>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
