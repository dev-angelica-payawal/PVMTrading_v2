﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PVMTrading_v1.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="aspnet-PVMTrading_v1-20180109093125")]
	public partial class OperationDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertCustomerCompleInfoe(CustomerCompleInfoe instance);
    partial void UpdateCustomerCompleInfoe(CustomerCompleInfoe instance);
    partial void DeleteCustomerCompleInfoe(CustomerCompleInfoe instance);
    #endregion
		
		public OperationDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public OperationDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OperationDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OperationDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OperationDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<CustomerCompleInfoe> CustomerCompleInfoes
		{
			get
			{
				return this.GetTable<CustomerCompleInfoe>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customers")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FirstName;
		
		private string _MiddleName;
		
		private string _LastName;
		
		private string _NameExtension;
		
		private int _Mobile;
		
		private int _Sexid;
		
		private System.DateTime _RegisteredDateCreated;
		
		private EntitySet<CustomerCompleInfoe> _CustomerCompleInfoes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnMiddleNameChanging(string value);
    partial void OnMiddleNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnNameExtensionChanging(string value);
    partial void OnNameExtensionChanged();
    partial void OnMobileChanging(int value);
    partial void OnMobileChanged();
    partial void OnSexidChanging(int value);
    partial void OnSexidChanged();
    partial void OnRegisteredDateCreatedChanging(System.DateTime value);
    partial void OnRegisteredDateCreatedChanged();
    #endregion
		
		public Customer()
		{
			this._CustomerCompleInfoes = new EntitySet<CustomerCompleInfoe>(new Action<CustomerCompleInfoe>(this.attach_CustomerCompleInfoes), new Action<CustomerCompleInfoe>(this.detach_CustomerCompleInfoes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(255)")]
		public string MiddleName
		{
			get
			{
				return this._MiddleName;
			}
			set
			{
				if ((this._MiddleName != value))
				{
					this.OnMiddleNameChanging(value);
					this.SendPropertyChanging();
					this._MiddleName = value;
					this.SendPropertyChanged("MiddleName");
					this.OnMiddleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NameExtension", DbType="NVarChar(255)")]
		public string NameExtension
		{
			get
			{
				return this._NameExtension;
			}
			set
			{
				if ((this._NameExtension != value))
				{
					this.OnNameExtensionChanging(value);
					this.SendPropertyChanging();
					this._NameExtension = value;
					this.SendPropertyChanged("NameExtension");
					this.OnNameExtensionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mobile", DbType="Int NOT NULL")]
		public int Mobile
		{
			get
			{
				return this._Mobile;
			}
			set
			{
				if ((this._Mobile != value))
				{
					this.OnMobileChanging(value);
					this.SendPropertyChanging();
					this._Mobile = value;
					this.SendPropertyChanged("Mobile");
					this.OnMobileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sexid", DbType="Int NOT NULL")]
		public int Sexid
		{
			get
			{
				return this._Sexid;
			}
			set
			{
				if ((this._Sexid != value))
				{
					this.OnSexidChanging(value);
					this.SendPropertyChanging();
					this._Sexid = value;
					this.SendPropertyChanged("Sexid");
					this.OnSexidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegisteredDateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime RegisteredDateCreated
		{
			get
			{
				return this._RegisteredDateCreated;
			}
			set
			{
				if ((this._RegisteredDateCreated != value))
				{
					this.OnRegisteredDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._RegisteredDateCreated = value;
					this.SendPropertyChanged("RegisteredDateCreated");
					this.OnRegisteredDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_CustomerCompleInfoe", Storage="_CustomerCompleInfoes", ThisKey="Id", OtherKey="CustomerId")]
		public EntitySet<CustomerCompleInfoe> CustomerCompleInfoes
		{
			get
			{
				return this._CustomerCompleInfoes;
			}
			set
			{
				this._CustomerCompleInfoes.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CustomerCompleInfoes(CustomerCompleInfoe entity)
		{
			this.SendPropertyChanging();
			entity.Customer = this;
		}
		
		private void detach_CustomerCompleInfoes(CustomerCompleInfoe entity)
		{
			this.SendPropertyChanging();
			entity.Customer = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CustomerCompleInfoes")]
	public partial class CustomerCompleInfoe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _CustomerId;
		
		private System.Nullable<int> _Telephone;
		
		private int _CustomerTypeId;
		
		private string _Email;
		
		private System.DateTime _Birthdate;
		
		private int _CivilStatusId;
		
		private string _PlaceOfBirth;
		
		private string _Nationality;
		
		private System.Nullable<int> _TaxIdentificationNumber;
		
		private string _LotHouseNumberAndStreet;
		
		private string _Barangay;
		
		private string _CityMunicipality;
		
		private string _Province;
		
		private string _Country;
		
		private System.Nullable<int> _ZipCode;
		
		private EntityRef<Customer> _Customer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCustomerIdChanging(int value);
    partial void OnCustomerIdChanged();
    partial void OnTelephoneChanging(System.Nullable<int> value);
    partial void OnTelephoneChanged();
    partial void OnCustomerTypeIdChanging(int value);
    partial void OnCustomerTypeIdChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnBirthdateChanging(System.DateTime value);
    partial void OnBirthdateChanged();
    partial void OnCivilStatusIdChanging(int value);
    partial void OnCivilStatusIdChanged();
    partial void OnPlaceOfBirthChanging(string value);
    partial void OnPlaceOfBirthChanged();
    partial void OnNationalityChanging(string value);
    partial void OnNationalityChanged();
    partial void OnTaxIdentificationNumberChanging(System.Nullable<int> value);
    partial void OnTaxIdentificationNumberChanged();
    partial void OnLotHouseNumberAndStreetChanging(string value);
    partial void OnLotHouseNumberAndStreetChanged();
    partial void OnBarangayChanging(string value);
    partial void OnBarangayChanged();
    partial void OnCityMunicipalityChanging(string value);
    partial void OnCityMunicipalityChanged();
    partial void OnProvinceChanging(string value);
    partial void OnProvinceChanged();
    partial void OnCountryChanging(string value);
    partial void OnCountryChanged();
    partial void OnZipCodeChanging(System.Nullable<int> value);
    partial void OnZipCodeChanged();
    #endregion
		
		public CustomerCompleInfoe()
		{
			this._Customer = default(EntityRef<Customer>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerId", DbType="Int NOT NULL")]
		public int CustomerId
		{
			get
			{
				return this._CustomerId;
			}
			set
			{
				if ((this._CustomerId != value))
				{
					if (this._Customer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustomerIdChanging(value);
					this.SendPropertyChanging();
					this._CustomerId = value;
					this.SendPropertyChanged("CustomerId");
					this.OnCustomerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telephone", DbType="Int")]
		public System.Nullable<int> Telephone
		{
			get
			{
				return this._Telephone;
			}
			set
			{
				if ((this._Telephone != value))
				{
					this.OnTelephoneChanging(value);
					this.SendPropertyChanging();
					this._Telephone = value;
					this.SendPropertyChanged("Telephone");
					this.OnTelephoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerTypeId", DbType="Int NOT NULL")]
		public int CustomerTypeId
		{
			get
			{
				return this._CustomerTypeId;
			}
			set
			{
				if ((this._CustomerTypeId != value))
				{
					this.OnCustomerTypeIdChanging(value);
					this.SendPropertyChanging();
					this._CustomerTypeId = value;
					this.SendPropertyChanged("CustomerTypeId");
					this.OnCustomerTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(255)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthdate", DbType="DateTime NOT NULL")]
		public System.DateTime Birthdate
		{
			get
			{
				return this._Birthdate;
			}
			set
			{
				if ((this._Birthdate != value))
				{
					this.OnBirthdateChanging(value);
					this.SendPropertyChanging();
					this._Birthdate = value;
					this.SendPropertyChanged("Birthdate");
					this.OnBirthdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CivilStatusId", DbType="Int NOT NULL")]
		public int CivilStatusId
		{
			get
			{
				return this._CivilStatusId;
			}
			set
			{
				if ((this._CivilStatusId != value))
				{
					this.OnCivilStatusIdChanging(value);
					this.SendPropertyChanging();
					this._CivilStatusId = value;
					this.SendPropertyChanged("CivilStatusId");
					this.OnCivilStatusIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlaceOfBirth", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string PlaceOfBirth
		{
			get
			{
				return this._PlaceOfBirth;
			}
			set
			{
				if ((this._PlaceOfBirth != value))
				{
					this.OnPlaceOfBirthChanging(value);
					this.SendPropertyChanging();
					this._PlaceOfBirth = value;
					this.SendPropertyChanged("PlaceOfBirth");
					this.OnPlaceOfBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nationality", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Nationality
		{
			get
			{
				return this._Nationality;
			}
			set
			{
				if ((this._Nationality != value))
				{
					this.OnNationalityChanging(value);
					this.SendPropertyChanging();
					this._Nationality = value;
					this.SendPropertyChanged("Nationality");
					this.OnNationalityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaxIdentificationNumber", DbType="Int")]
		public System.Nullable<int> TaxIdentificationNumber
		{
			get
			{
				return this._TaxIdentificationNumber;
			}
			set
			{
				if ((this._TaxIdentificationNumber != value))
				{
					this.OnTaxIdentificationNumberChanging(value);
					this.SendPropertyChanging();
					this._TaxIdentificationNumber = value;
					this.SendPropertyChanged("TaxIdentificationNumber");
					this.OnTaxIdentificationNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LotHouseNumberAndStreet", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string LotHouseNumberAndStreet
		{
			get
			{
				return this._LotHouseNumberAndStreet;
			}
			set
			{
				if ((this._LotHouseNumberAndStreet != value))
				{
					this.OnLotHouseNumberAndStreetChanging(value);
					this.SendPropertyChanging();
					this._LotHouseNumberAndStreet = value;
					this.SendPropertyChanged("LotHouseNumberAndStreet");
					this.OnLotHouseNumberAndStreetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Barangay", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Barangay
		{
			get
			{
				return this._Barangay;
			}
			set
			{
				if ((this._Barangay != value))
				{
					this.OnBarangayChanging(value);
					this.SendPropertyChanging();
					this._Barangay = value;
					this.SendPropertyChanged("Barangay");
					this.OnBarangayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityMunicipality", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string CityMunicipality
		{
			get
			{
				return this._CityMunicipality;
			}
			set
			{
				if ((this._CityMunicipality != value))
				{
					this.OnCityMunicipalityChanging(value);
					this.SendPropertyChanging();
					this._CityMunicipality = value;
					this.SendPropertyChanged("CityMunicipality");
					this.OnCityMunicipalityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Province", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Province
		{
			get
			{
				return this._Province;
			}
			set
			{
				if ((this._Province != value))
				{
					this.OnProvinceChanging(value);
					this.SendPropertyChanging();
					this._Province = value;
					this.SendPropertyChanged("Province");
					this.OnProvinceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Country", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Country
		{
			get
			{
				return this._Country;
			}
			set
			{
				if ((this._Country != value))
				{
					this.OnCountryChanging(value);
					this.SendPropertyChanging();
					this._Country = value;
					this.SendPropertyChanged("Country");
					this.OnCountryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZipCode", DbType="Int")]
		public System.Nullable<int> ZipCode
		{
			get
			{
				return this._ZipCode;
			}
			set
			{
				if ((this._ZipCode != value))
				{
					this.OnZipCodeChanging(value);
					this.SendPropertyChanging();
					this._ZipCode = value;
					this.SendPropertyChanged("ZipCode");
					this.OnZipCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_CustomerCompleInfoe", Storage="_Customer", ThisKey="CustomerId", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Customer Customer
		{
			get
			{
				return this._Customer.Entity;
			}
			set
			{
				Customer previousValue = this._Customer.Entity;
				if (((previousValue != value) 
							|| (this._Customer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Customer.Entity = null;
						previousValue.CustomerCompleInfoes.Remove(this);
					}
					this._Customer.Entity = value;
					if ((value != null))
					{
						value.CustomerCompleInfoes.Add(this);
						this._CustomerId = value.Id;
					}
					else
					{
						this._CustomerId = default(int);
					}
					this.SendPropertyChanged("Customer");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
