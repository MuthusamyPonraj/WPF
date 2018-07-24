using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexerBindingDemo
{
    public class PropertyInfo
    {
        private string _key;

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key
        {
            get
            {
                return _key;
            }
            internal set
            {
                _key = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified key.
        /// </summary>
        /// <value></value>
        public string this[string key]
        {
            get
            {
                return this.Value;
            }
            set
            {
                this.Value = value;
            }
        }
    }
}
