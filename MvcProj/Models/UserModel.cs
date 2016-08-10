using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProj.Models
{
    public class UserModel
    {
        public UserModel()
		{}
		#region Model
		private int? _id;
		private string _name;
		private string _age;
		private string _phone;
		private string _adress;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int? id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adress
		{
			set{ _adress=value;}
			get{return _adress;}
		}
		#endregion Model
    }
}