using System;
using OrderProcess.Data;
using OrderProcess.Data.Interface;

namespace OrderProcess.Domain
{
    public class DeliveryDriver : UserDTO, IConsolidate
    {
        public DeliveryDriver()
        {
            UserName = "Billy";
        }

        public void Consolidate()
        {
            throw new NotImplementedException();
        }
    }
}