﻿/**  版本信息模板在安装目录下，可自行修改。
* blogtypenotb.cs
*
* 功 能： N/A
* 类 名： blogtypenotb
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/27 15:40:18   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BlogSpace.Model.Blog
{
	/// <summary>
	/// blogtypenotb:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class blogtypenotb
	{
		public blogtypenotb()
		{}
		#region Model
		private int _id;
		private string _type;
		private string _typeno;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeNo
		{
			set{ _typeno=value;}
			get{return _typeno;}
		}
		#endregion Model

	}
}

