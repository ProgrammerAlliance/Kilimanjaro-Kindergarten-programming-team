/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2018/1/29 16:59:45                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Menu') and o.name = 'FK_MENU_REFERENCE_MENUTYPE')
alter table Menu
   drop constraint FK_MENU_REFERENCE_MENUTYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderingInformation') and o.name = 'FK_ORDERING_REFERENCE_STAFFINF')
alter table OrderingInformation
   drop constraint FK_ORDERING_REFERENCE_STAFFINF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderingInformation') and o.name = 'FK_ORDERING_REFERENCE_MENU')
alter table OrderingInformation
   drop constraint FK_ORDERING_REFERENCE_MENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderingInformation') and o.name = 'FK_ORDERING_REFERENCE_ORDERING')
alter table OrderingInformation
   drop constraint FK_ORDERING_REFERENCE_ORDERING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StaffInformation') and o.name = 'FK_STAFFINF_REFERENCE_USERTYPE')
alter table StaffInformation
   drop constraint FK_STAFFINF_REFERENCE_USERTYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StaffInformation') and o.name = 'FK_STAFFINF_REFERENCE_DEPARTME')
alter table StaffInformation
   drop constraint FK_STAFFINF_REFERENCE_DEPARTME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserType') and o.name = 'FK_USERTYPE_REFERENCE_AUTHORIT')
alter table UserType
   drop constraint FK_USERTYPE_REFERENCE_AUTHORIT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Authority')
            and   type = 'U')
   drop table Authority
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Department')
            and   type = 'U')
   drop table Department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Menu')
            and   type = 'U')
   drop table Menu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MenuType')
            and   type = 'U')
   drop table MenuType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OrderingInformation')
            and   type = 'U')
   drop table OrderingInformation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OrderingState')
            and   type = 'U')
   drop table OrderingState
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StaffInformation')
            and   type = 'U')
   drop table StaffInformation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserType')
            and   type = 'U')
   drop table UserType
go

/*==============================================================*/
/* Table: Authority                                             */
/*==============================================================*/
create table Authority (
   TypeID               int                  not null,
   Privilege            varchar(50)          not null,
   constraint PK_AUTHORITY primary key (TypeID)
)
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Department (
   DepartmentID         int                  not null,
   DepartmentName       varchar(50)          not null,
   constraint PK_DEPARTMENT primary key (DepartmentID)
)
go

/*==============================================================*/
/* Table: Menu                                                  */
/*==============================================================*/
create table Menu (
   MenuID               int                  not null,
   MenuTypeID           int                  not null,
   MenuName             char(50)             not null,
   "Unit price"         float                not null,
   "Total Money"        float                not null,
   TypeName             varchar(50)          not null,
   constraint PK_MENU primary key (MenuID)
)
go

/*==============================================================*/
/* Table: MenuType                                              */
/*==============================================================*/
create table MenuType (
   MenuTypeID           int                  not null,
   TypeName             varchar(50)          not null,
   constraint PK_MENUTYPE primary key (MenuTypeID)
)
go

/*==============================================================*/
/* Table: OrderingInformation                                   */
/*==============================================================*/
create table OrderingInformation (
   OrderID              int                  not null,
   MenuID               int                  not null,
   StaffName            varchar(50)          not null,
   OrderPersonCount     int                  not null,
   OrderMenuCount       int                  not null,
   OrderMoney           float                not null,
   MenuName             varchar(50)          not null,
   Budget               float                not null,
   DateTime             datetime             not null,
   ClearPeople          int                  not null,
   OrderingStateID      int                  not null,
   StaffID              int                  not null,
   constraint PK_ORDERINGINFORMATION primary key (OrderID)
)
go

/*==============================================================*/
/* Table: OrderingState                                         */
/*==============================================================*/
create table OrderingState (
   OrderingStateID      int                  not null,
   OrderingStateName    varchar(50)          not null,
   constraint PK_ORDERINGSTATE primary key (OrderingStateID)
)
go

/*==============================================================*/
/* Table: StaffInformation                                      */
/*==============================================================*/
create table StaffInformation (
   StaffID              int                  not null,
   DepartmentID         int                  not null,
   UserID               int                  not null,
   StaffName            varchar(50)          not null,
   Password             varchar(50)          not null,
   UserName             varchar(50)          not null,
   DepartmentName       varchar(50)          not null,
   constraint PK_STAFFINFORMATION primary key (StaffID)
)
go

/*==============================================================*/
/* Table: UserType                                              */
/*==============================================================*/
create table UserType (
   UserID               int                  not null,
   TypeID               int                  not null,
   PassWord             varchar(50)          not null,
   UserName             varchar(50)          not null,
   constraint PK_USERTYPE primary key (UserID)
)
go

alter table Menu
   add constraint FK_MENU_REFERENCE_MENUTYPE foreign key (MenuTypeID)
      references MenuType (MenuTypeID)
go

alter table OrderingInformation
   add constraint FK_ORDERING_REFERENCE_STAFFINF foreign key (StaffID)
      references StaffInformation (StaffID)
go

alter table OrderingInformation
   add constraint FK_ORDERING_REFERENCE_MENU foreign key (MenuID)
      references Menu (MenuID)
go

alter table OrderingInformation
   add constraint FK_ORDERING_REFERENCE_ORDERING foreign key (OrderingStateID)
      references OrderingState (OrderingStateID)
go

alter table StaffInformation
   add constraint FK_STAFFINF_REFERENCE_USERTYPE foreign key (UserID)
      references UserType (UserID)
go

alter table StaffInformation
   add constraint FK_STAFFINF_REFERENCE_DEPARTME foreign key (DepartmentID)
      references Department (DepartmentID)
go

alter table UserType
   add constraint FK_USERTYPE_REFERENCE_AUTHORIT foreign key (TypeID)
      references Authority (TypeID)
go

