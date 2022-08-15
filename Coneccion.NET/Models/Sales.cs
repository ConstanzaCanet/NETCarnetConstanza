using System;

namespace Coneccion.NET.Models
{
    public class Sale
    {
        public int Id;
        public string coments;

        public Sale()
        {
            Id = 0;
            coments = String.Empty;
        }

        public Sale(int id, string coments)
        {
            this.Id = id;
            this.coments = coments;
        }

        //setters & getters
        public int ID
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = value;
            }

        }

        public string Coments
        {
            get
            {
                return this.coments;
            }
            set
            {
                this.coments = value;
            }
        }

    }
}
