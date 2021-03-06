﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Web;
using Shop.Model;
using Shop.DataAccess;
namespace Shop.SQLDataAccess
{

	public interface Lebi_Supplier_Power_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Supplier_Power model);
		void Update(Lebi_Supplier_Power model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Supplier_Power GetModel(int id);
		Lebi_Supplier_Power GetModel(string strWhere);
		Lebi_Supplier_Power GetModel(SQLPara para);
		List<Lebi_Supplier_Power> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Supplier_Power> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Supplier_Power> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Supplier_Power> GetList(SQLPara para);
		Lebi_Supplier_Power BindForm(Lebi_Supplier_Power model);
		Lebi_Supplier_Power SafeBindForm(Lebi_Supplier_Power model);
		Lebi_Supplier_Power ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Supplier_Power。
	/// </summary>
	public class D_Lebi_Supplier_Power
	{
		static Lebi_Supplier_Power_interface _Instance;
		public static Lebi_Supplier_Power_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Supplier_Power();
		            else
		                _Instance = new sqlserver_Lebi_Supplier_Power();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Supplier_Power()
		{}
		#region  成员方法
	class sqlserver_Lebi_Supplier_Power : Lebi_Supplier_Power_interface
	{
		/// <summary>
		/// 根据字段名，where条件获取一个值,返回字符串
		/// </summary>
		public string GetValue(string colName,string strWhere)
		{
			string val = "";
			try
			{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("select " + colName + " from [Lebi_Supplier_Power]");
				if(strWhere.Trim()!="")
				{
					strSql.Append(" where "+strWhere);
				}
				val = Convert.ToString(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
			}
			catch
			{
				val = "";
			}
			return val;
		}
		public string GetValue(string colName,SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  "+colName+" from [Lebi_Supplier_Power]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToString( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}

		/// <summary>
		/// 计算记录条数
		/// </summary>
		public int Counts(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return Counts(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Power]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Power]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetMaxID(para);
			}
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select max(id) from [Lebi_Supplier_Power]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Power]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_Power model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_Power](");
			strSql.Append("Supplier_Group_id,Supplier_Limit_id,Supplier_Limit_Code,Url)");
			strSql.Append(" values (");
			strSql.Append("@Supplier_Group_id,@Supplier_Limit_id,@Supplier_Limit_Code,@Url)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Supplier_Group_id", model.Supplier_Group_id),
					new SqlParameter("@Supplier_Limit_id", model.Supplier_Limit_id),
					new SqlParameter("@Supplier_Limit_Code", model.Supplier_Limit_Code),
					new SqlParameter("@Url", model.Url)};

			object obj = SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Supplier_Power model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_Power] set ");
			strSql.Append("Supplier_Group_id= @Supplier_Group_id,");
			strSql.Append("Supplier_Limit_id= @Supplier_Limit_id,");
			strSql.Append("Supplier_Limit_Code= @Supplier_Limit_Code,");
			strSql.Append("Url= @Url");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_Group_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_Limit_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_Limit_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Url", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Supplier_Group_id;
			parameters[2].Value = model.Supplier_Limit_id;
			parameters[3].Value = model.Supplier_Limit_Code;
			parameters[4].Value = model.Url;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Power] ");
			strSql.Append(" where @id=id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除多条数据  by where条件
		/// </summary>
		public void Delete(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				Delete(para);
				return;
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Power] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Power] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_Power GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Power] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Supplier_Power model=new Lebi_Supplier_Power();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString()!="")
				{
					model.Supplier_Group_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Limit_id"].ToString()!="")
				{
					model.Supplier_Limit_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Limit_id"].ToString());
				}
				model.Supplier_Limit_Code=ds.Tables[0].Rows[0]["Supplier_Limit_Code"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 得到一个对象实体 by where条件
		/// </summary>
		public Lebi_Supplier_Power GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Power] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_Power model=new Lebi_Supplier_Power();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString()!="")
				{
					model.Supplier_Group_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Limit_id"].ToString()!="")
				{
					model.Supplier_Limit_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Limit_id"].ToString());
				}
				model.Supplier_Limit_Code=ds.Tables[0].Rows[0]["Supplier_Limit_Code"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 得到一个对象实体 by SQLpara
		/// </summary>
		public Lebi_Supplier_Power GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_Power] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_Power model=new Lebi_Supplier_Power();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString()!="")
				{
					model.Supplier_Group_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Limit_id"].ToString()!="")
				{
					model.Supplier_Limit_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Limit_id"].ToString());
				}
				model.Supplier_Limit_Code=ds.Tables[0].Rows[0]["Supplier_Limit_Code"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表-带分页
		/// </summary>
		public List<Lebi_Supplier_Power> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_Power]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Supplier_Power> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_Power]";
			string strFieldKey = "id";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top " + PageSize + " " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (page > 1)
			{
				if (para != null)
					strSql.Append(" and ");
				else
					strSql.Append(" where ");
				strSql.Append(strFieldKey + " not in (select top " + (PageSize * (page - 1)) + " " + strFieldKey + " from " + strTableName + "");
				if (para != null)
					strSql.Append(" where " + para.Where + "");
				if (para.Order != "")
					strSql.Append(" order by " + para.Order + "");
				strSql.Append(")");
			}
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString(), para.Para))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

		/// <summary>
		/// 获得数据列表-不带分页
		/// </summary>
		public List<Lebi_Supplier_Power> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_Power] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Supplier_Power> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_Power]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString(), para.Para))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 绑定对象表单
		/// </summary>
		public Lebi_Supplier_Power BindForm(Lebi_Supplier_Power model)
		{
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_id"] != null)
				model.Supplier_Limit_id=Shop.Tools.RequestTool.RequestInt("Supplier_Limit_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_Code"] != null)
				model.Supplier_Limit_Code=Shop.Tools.RequestTool.RequestString("Supplier_Limit_Code");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_Power SafeBindForm(Lebi_Supplier_Power model)
		{
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_id"] != null)
				model.Supplier_Limit_id=Shop.Tools.RequestTool.RequestInt("Supplier_Limit_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_Code"] != null)
				model.Supplier_Limit_Code=Shop.Tools.RequestTool.RequestSafeString("Supplier_Limit_Code");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_Power ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_Power model=new Lebi_Supplier_Power();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Supplier_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Group_id=(int)ojb;
			}
			ojb = dataReader["Supplier_Limit_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Limit_id=(int)ojb;
			}
			model.Supplier_Limit_Code=dataReader["Supplier_Limit_Code"].ToString();
			model.Url=dataReader["Url"].ToString();
			return model;
		}

	}
	class access_Lebi_Supplier_Power : Lebi_Supplier_Power_interface
	{
		/// <summary>
		/// 根据字段名，where条件获取一个值,返回字符串
		/// </summary>
		public string GetValue(string colName,string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			string val = "";
			try
			{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("select " + colName + " from [Lebi_Supplier_Power]");
				if(strWhere.Trim()!="")
				{
					strSql.Append(" where "+strWhere);
				}
				val = Convert.ToString(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
			}
			catch
			{
				val = "";
			}
			return val;
		}
		public string GetValue(string colName,SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  "+colName+" from [Lebi_Supplier_Power]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToString(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}

		/// <summary>
		/// 计算记录条数
		/// </summary>
		public int Counts(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return Counts(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Supplier_Power]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Supplier_Power]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetMaxID(para);
			}
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select max(id) from [Lebi_Supplier_Power]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Power]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_Power model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_Power](");
			strSql.Append("[Supplier_Group_id],[Supplier_Limit_id],[Supplier_Limit_Code],[Url])");
			strSql.Append(" values (");
			strSql.Append("@Supplier_Group_id,@Supplier_Limit_id,@Supplier_Limit_Code,@Url)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Supplier_Group_id", model.Supplier_Group_id),
					new OleDbParameter("@Supplier_Limit_id", model.Supplier_Limit_id),
					new OleDbParameter("@Supplier_Limit_Code", model.Supplier_Limit_Code),
					new OleDbParameter("@Url", model.Url)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Supplier_Power model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_Power] set ");
			strSql.Append("[Supplier_Group_id]=@Supplier_Group_id,");
			strSql.Append("[Supplier_Limit_id]=@Supplier_Limit_id,");
			strSql.Append("[Supplier_Limit_Code]=@Supplier_Limit_Code,");
			strSql.Append("[Url]=@Url");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Supplier_Group_id", model.Supplier_Group_id),
					new OleDbParameter("@Supplier_Limit_id", model.Supplier_Limit_id),
					new OleDbParameter("@Supplier_Limit_Code", model.Supplier_Limit_Code),
					new OleDbParameter("@Url", model.Url)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Power] ");
			strSql.Append(" where @id=id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除多条数据  by where条件
		/// </summary>
		public void Delete(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				Delete(para);
				return;
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Power] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Power] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_Power GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Power] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Supplier_Power model;
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), parameters))
			{
			    if (dataReader != null)
			    {
			       while (dataReader.Read())
			       {
			           model = ReaderBind(dataReader);
			           return model;
			       }
			    }
			}
			return null;
		}
		/// <summary>
		/// 得到一个对象实体 by where条件
		/// </summary>
		public Lebi_Supplier_Power GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Power] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_Power model;
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), null))
			{
			    if (dataReader != null)
			    {
			       while (dataReader.Read())
			       {
			           model = ReaderBind(dataReader);
			           return model;
			       }
			    }
			}
			return null;
		}
		/// <summary>
		/// 得到一个对象实体 by SQLpara
		/// </summary>
		public Lebi_Supplier_Power GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_Power] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_Power model;
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), para.Para_Oledb))
			{
			    if (dataReader != null)
			    {
			       while (dataReader.Read())
			       {
			           model = ReaderBind(dataReader);
			           return model;
			       }
			    }
			}
			return null;
		}

		/// <summary>
		/// 获得数据列表-带分页
		/// </summary>
		public List<Lebi_Supplier_Power> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_Power]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (IDataReader dataReader = AccessUtils.Instance.DataReader(strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page,null))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
				return list;
			}
		public List<Lebi_Supplier_Power> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_Power]";
			string strFieldKey = "id";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top " + PageSize + " " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (page > 1)
			{
				if (para != null)
					strSql.Append(" and ");
				else
					strSql.Append(" where ");
				strSql.Append(strFieldKey + " not in (select top " + (PageSize * (page - 1)) + " " + strFieldKey + " from " + strTableName + "");
				if (para != null)
					strSql.Append(" where " + para.Where + "");
				if (para.Order != "")
					strSql.Append(" order by " + para.Order + "");
				strSql.Append(")");
			}
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (IDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), para.Para_Oledb))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
			return list;
		}

		/// <summary>
		/// 获得数据列表-不带分页
		/// </summary>
		public List<Lebi_Supplier_Power> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_Power] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(),null))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
			return list;
		}
		public List<Lebi_Supplier_Power> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_Power]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Power> list = new List<Lebi_Supplier_Power>();
			using (IDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), para.Para_Oledb))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
			return list;
		}


		/// <summary>
		/// 绑定对象表单
		/// </summary>
		public Lebi_Supplier_Power BindForm(Lebi_Supplier_Power model)
		{
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_id"] != null)
				model.Supplier_Limit_id=Shop.Tools.RequestTool.RequestInt("Supplier_Limit_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_Code"] != null)
				model.Supplier_Limit_Code=Shop.Tools.RequestTool.RequestString("Supplier_Limit_Code");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_Power SafeBindForm(Lebi_Supplier_Power model)
		{
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_id"] != null)
				model.Supplier_Limit_id=Shop.Tools.RequestTool.RequestInt("Supplier_Limit_id",0);
			if (HttpContext.Current.Request["Supplier_Limit_Code"] != null)
				model.Supplier_Limit_Code=Shop.Tools.RequestTool.RequestSafeString("Supplier_Limit_Code");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_Power ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_Power model=new Lebi_Supplier_Power();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Supplier_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Group_id=(int)ojb;
			}
			ojb = dataReader["Supplier_Limit_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Limit_id=(int)ojb;
			}
			model.Supplier_Limit_Code=dataReader["Supplier_Limit_Code"].ToString();
			model.Url=dataReader["Url"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

