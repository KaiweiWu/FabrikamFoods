using FabrikamFoods.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamFoods
{
    class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<menutable> menuTable;
        private IMobileServiceTable<usertable> userTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://appfabrikam.azurewebsites.net/");
            this.menuTable = this.client.GetTable<menutable>();
            this.userTable = this.client.GetTable<usertable>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }
        public async Task<List<menutable>> GetMenuTable()
        {
            return await this.menuTable.ToListAsync();
        }

        public async Task<List<usertable>> GetUsers()
        {
            return await this.userTable.ToListAsync();
        }

        public async Task AddUser(usertable entry)
        {
            await this.userTable.InsertAsync(entry);
        }

        public async Task UpdateUser(usertable user)
        {
            await this.userTable.UpdateAsync(user);
        }

    }
}
