using MvcProj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProj.DB
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class LDBContext : System.Data.Entity.DbContext
    {
        #region 变量属性

        public LDBContext()
            : base("name=homecoming")
        {
            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            // DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());

            // strConn = connString;
            // Database.SetInitializer<SysDb>(null);//设置为空，防止自动检查和生成
        }


        public static LDBContext instanceDB = new LDBContext();

        /// <summary>
        /// 数据访问公开实例对象
        /// </summary>
        public static LDBContext InstanceDB
        {
            get
            {
                if (instanceDB == null)
                    instanceDB = new LDBContext();
                return instanceDB;
            }
        }
        #endregion


        public virtual DbSet<UserModel> userinfotb{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CountryRetailer>()
            //    .Property(e => e.Status)
            //    .IsUnicode(false);
            //modelBuilder.Entity<TB_Store>().Property(x => x.Latitude).HasPrecision(18, 4);
            //modelBuilder.Entity<TB_Store>().Property(x => x.Longitude).HasPrecision(18, 4);

            base.OnModelCreating(modelBuilder);
        }
    }
}