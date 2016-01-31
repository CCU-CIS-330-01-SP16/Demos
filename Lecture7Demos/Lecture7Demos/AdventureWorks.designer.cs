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

namespace Lecture7Demos
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AdventureWorks2014")]
	public partial class AdventureWorksDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPerson(Person instance);
    partial void UpdatePerson(Person instance);
    partial void DeletePerson(Person instance);
    partial void InsertPersonPhone(PersonPhone instance);
    partial void UpdatePersonPhone(PersonPhone instance);
    partial void DeletePersonPhone(PersonPhone instance);
    #endregion
		
		public AdventureWorksDataContext() : 
				base(global::Lecture7Demos.Properties.Settings.Default.AdventureWorks2014ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Person> Persons
		{
			get
			{
				return this.GetTable<Person>();
			}
		}
		
		public System.Data.Linq.Table<PersonPhone> PersonPhones
		{
			get
			{
				return this.GetTable<PersonPhone>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Person.Person")]
	public partial class Person : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BusinessEntityID;
		
		private string _PersonType;
		
		private bool _NameStyle;
		
		private string _Title;
		
		private string _FirstName;
		
		private string _MiddleName;
		
		private string _LastName;
		
		private string _Suffix;
		
		private int _EmailPromotion;
		
		private System.Xml.Linq.XElement _AdditionalContactInfo;
		
		private System.Xml.Linq.XElement _Demographics;
		
		private System.Guid _rowguid;
		
		private System.DateTime _ModifiedDate;
		
		private EntitySet<PersonPhone> _PersonPhones;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBusinessEntityIDChanging(int value);
    partial void OnBusinessEntityIDChanged();
    partial void OnPersonTypeChanging(string value);
    partial void OnPersonTypeChanged();
    partial void OnNameStyleChanging(bool value);
    partial void OnNameStyleChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnMiddleNameChanging(string value);
    partial void OnMiddleNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnSuffixChanging(string value);
    partial void OnSuffixChanged();
    partial void OnEmailPromotionChanging(int value);
    partial void OnEmailPromotionChanged();
    partial void OnAdditionalContactInfoChanging(System.Xml.Linq.XElement value);
    partial void OnAdditionalContactInfoChanged();
    partial void OnDemographicsChanging(System.Xml.Linq.XElement value);
    partial void OnDemographicsChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public Person()
		{
			this._PersonPhones = new EntitySet<PersonPhone>(new Action<PersonPhone>(this.attach_PersonPhones), new Action<PersonPhone>(this.detach_PersonPhones));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessEntityID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BusinessEntityID
		{
			get
			{
				return this._BusinessEntityID;
			}
			set
			{
				if ((this._BusinessEntityID != value))
				{
					this.OnBusinessEntityIDChanging(value);
					this.SendPropertyChanging();
					this._BusinessEntityID = value;
					this.SendPropertyChanged("BusinessEntityID");
					this.OnBusinessEntityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PersonType", DbType="NChar(2) NOT NULL", CanBeNull=false)]
		public string PersonType
		{
			get
			{
				return this._PersonType;
			}
			set
			{
				if ((this._PersonType != value))
				{
					this.OnPersonTypeChanging(value);
					this.SendPropertyChanging();
					this._PersonType = value;
					this.SendPropertyChanged("PersonType");
					this.OnPersonTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NameStyle", DbType="Bit NOT NULL")]
		public bool NameStyle
		{
			get
			{
				return this._NameStyle;
			}
			set
			{
				if ((this._NameStyle != value))
				{
					this.OnNameStyleChanging(value);
					this.SendPropertyChanging();
					this._NameStyle = value;
					this.SendPropertyChanged("NameStyle");
					this.OnNameStyleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(8)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)")]
		public string Suffix
		{
			get
			{
				return this._Suffix;
			}
			set
			{
				if ((this._Suffix != value))
				{
					this.OnSuffixChanging(value);
					this.SendPropertyChanging();
					this._Suffix = value;
					this.SendPropertyChanged("Suffix");
					this.OnSuffixChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL")]
		public int EmailPromotion
		{
			get
			{
				return this._EmailPromotion;
			}
			set
			{
				if ((this._EmailPromotion != value))
				{
					this.OnEmailPromotionChanging(value);
					this.SendPropertyChanging();
					this._EmailPromotion = value;
					this.SendPropertyChanged("EmailPromotion");
					this.OnEmailPromotionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdditionalContactInfo", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement AdditionalContactInfo
		{
			get
			{
				return this._AdditionalContactInfo;
			}
			set
			{
				if ((this._AdditionalContactInfo != value))
				{
					this.OnAdditionalContactInfoChanging(value);
					this.SendPropertyChanging();
					this._AdditionalContactInfo = value;
					this.SendPropertyChanged("AdditionalContactInfo");
					this.OnAdditionalContactInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Demographics", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement Demographics
		{
			get
			{
				return this._Demographics;
			}
			set
			{
				if ((this._Demographics != value))
				{
					this.OnDemographicsChanging(value);
					this.SendPropertyChanging();
					this._Demographics = value;
					this.SendPropertyChanged("Demographics");
					this.OnDemographicsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Person_PersonPhone", Storage="_PersonPhones", ThisKey="BusinessEntityID", OtherKey="BusinessEntityID")]
		public EntitySet<PersonPhone> PersonPhones
		{
			get
			{
				return this._PersonPhones;
			}
			set
			{
				this._PersonPhones.Assign(value);
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
		
		private void attach_PersonPhones(PersonPhone entity)
		{
			this.SendPropertyChanging();
			entity.Person = this;
		}
		
		private void detach_PersonPhones(PersonPhone entity)
		{
			this.SendPropertyChanging();
			entity.Person = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Person.PersonPhone")]
	public partial class PersonPhone : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BusinessEntityID;
		
		private string _PhoneNumber;
		
		private int _PhoneNumberTypeID;
		
		private System.DateTime _ModifiedDate;
		
		private EntityRef<Person> _Person;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBusinessEntityIDChanging(int value);
    partial void OnBusinessEntityIDChanged();
    partial void OnPhoneNumberChanging(string value);
    partial void OnPhoneNumberChanged();
    partial void OnPhoneNumberTypeIDChanging(int value);
    partial void OnPhoneNumberTypeIDChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public PersonPhone()
		{
			this._Person = default(EntityRef<Person>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessEntityID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BusinessEntityID
		{
			get
			{
				return this._BusinessEntityID;
			}
			set
			{
				if ((this._BusinessEntityID != value))
				{
					if (this._Person.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBusinessEntityIDChanging(value);
					this.SendPropertyChanging();
					this._BusinessEntityID = value;
					this.SendPropertyChanged("BusinessEntityID");
					this.OnBusinessEntityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string PhoneNumber
		{
			get
			{
				return this._PhoneNumber;
			}
			set
			{
				if ((this._PhoneNumber != value))
				{
					this.OnPhoneNumberChanging(value);
					this.SendPropertyChanging();
					this._PhoneNumber = value;
					this.SendPropertyChanged("PhoneNumber");
					this.OnPhoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumberTypeID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PhoneNumberTypeID
		{
			get
			{
				return this._PhoneNumberTypeID;
			}
			set
			{
				if ((this._PhoneNumberTypeID != value))
				{
					this.OnPhoneNumberTypeIDChanging(value);
					this.SendPropertyChanging();
					this._PhoneNumberTypeID = value;
					this.SendPropertyChanged("PhoneNumberTypeID");
					this.OnPhoneNumberTypeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Person_PersonPhone", Storage="_Person", ThisKey="BusinessEntityID", OtherKey="BusinessEntityID", IsForeignKey=true)]
		public Person Person
		{
			get
			{
				return this._Person.Entity;
			}
			set
			{
				Person previousValue = this._Person.Entity;
				if (((previousValue != value) 
							|| (this._Person.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Person.Entity = null;
						previousValue.PersonPhones.Remove(this);
					}
					this._Person.Entity = value;
					if ((value != null))
					{
						value.PersonPhones.Add(this);
						this._BusinessEntityID = value.BusinessEntityID;
					}
					else
					{
						this._BusinessEntityID = default(int);
					}
					this.SendPropertyChanged("Person");
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
