/****** Object:  Table ActionDescription    Script Date: 02.01.2020 12:23:12 ******/
CREATE TABLE ActionDescription(
	ActionID int AUTO_INCREMENT NOT NULL,
	Description nvarchar(200) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ActionID););/****** Object:  Table Alert    Script Date: 02.01.2020 12:23:12 ******/
CREATE TABLE Alert(
	AlertID int AUTO_INCREMENT NOT NULL,
	AlertOccuranceDate datetime NOT NULL,
	AlertTypeID int NULL,
	AlertShownUserMapID int NULL,
	AlertDBCreationDate datetime NULL,
	AlertShownDate datetime NULL,
	AlertDeliveredDate datetime NULL,
	AlertClosedDate datetime NULL,
	AlertDeliveredUserMapID int NULL,
	AlertClosedUserMapID int NULL,
	Comment nvarchar(250) NULL,
	IMEI varchar(50) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	EventCodeID int NULL,
	EventParam int NULL,
 PRIMARY KEY (AlertID););/****** Object:  Table AlertTypeDictionary    Script Date: 02.01.2020 12:23:12 ******/
CREATE TABLE AlertTypeDictionary(
	AlertTypeID int NOT NULL,
	AlertDescription nvarchar(250) NULL,
	AlertName nvarchar(250) NOT NULL,
	AlertShouldNotify bit NULL,
	IsActual bit NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	EventGroupID int NULL,
 PRIMARY KEY (AlertTypeID););/****** Object:  Table aspnet_Applications    Script Date: 02.01.2020 12:23:12 ******/
CREATE TABLE aspnet_Applications(
	ApplicationName nvarchar(256) NOT NULL,
	LoweredApplicationName nvarchar(256) NOT NULL,
	ApplicationId char(32) NOT NULL,
	Description nvarchar(256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	ApplicationId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);,
UNIQUE NONCLUSTERED 
(
	LoweredApplicationName
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);,
UNIQUE NONCLUSTERED 
(
	ApplicationName
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table aspnet_Membership    Script Date: 02.01.2020 12:23:12 ******/
CREATE TABLE aspnet_Membership(
	ApplicationId char(32) NOT NULL,
	UserId char(32) NOT NULL,
	Password nvarchar(128) NOT NULL,
	PasswordFormat int NOT NULL,
	PasswordSalt nvarchar(128) NOT NULL,
	MobilePIN nvarchar(16) NULL,
	Email nvarchar(256) NULL,
	LoweredEmail nvarchar(256) NULL,
	PasswordQuestion nvarchar(256) NULL,
	PasswordAnswer nvarchar(128) NULL,
	IsApproved bit NOT NULL,
	IsLockedOut bit NOT NULL,
	CreateDate datetime NOT NULL,
	LastLoginDate datetime NOT NULL,
	LastPasswordChangedDate datetime NOT NULL,
	LastLockoutDate datetime NOT NULL,
	FailedPasswordAttemptCount int NOT NULL,
	FailedPasswordAttemptWindowStart datetime NOT NULL,
	FailedPasswordAnswerAttemptCount int NOT NULL,
	FailedPasswordAnswerAttemptWindowStart datetime NOT NULL,
	Comment text NULL,
PRIMARY KEY NONCLUSTERED 
(
	UserId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););TEXTIMAGE_;/****** Object:  Table aspnet_Paths    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_Paths(
	ApplicationId char(32) NOT NULL,
	PathId char(32) NOT NULL,
	Path nvarchar(256) NOT NULL,
	LoweredPath nvarchar(256) NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	PathId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table aspnet_PersonalizationAllUsers    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_PersonalizationAllUsers(
	PathId char(32) NOT NULL,
	PageSettings BLOB NOT NULL,
	LastUpdatedDate datetime NOT NULL,
PRIMARY KEY CLUSTERED 
(
	PathId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););TEXTIMAGE_;/****** Object:  Table aspnet_PersonalizationPerUser    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_PersonalizationPerUser(
	Id char(32) NOT NULL,
	PathId char(32) NULL,
	UserId char(32) NULL,
	PageSettings BLOB NOT NULL,
	LastUpdatedDate datetime NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	Id
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););TEXTIMAGE_;/****** Object:  Table aspnet_Profile    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_Profile(
	UserId char(32) NOT NULL,
	PropertyNames text NOT NULL,
	PropertyValuesString text NOT NULL,
	PropertyValuesBinary BLOB NOT NULL,
	LastUpdatedDate datetime NOT NULL,
PRIMARY KEY CLUSTERED 
(
	UserId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););TEXTIMAGE_;/****** Object:  Table aspnet_Roles    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_Roles(
	ApplicationId char(32) NOT NULL,
	RoleId char(32) NOT NULL,
	RoleName nvarchar(256) NOT NULL,
	LoweredRoleName nvarchar(256) NOT NULL,
	Description nvarchar(256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	RoleId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table aspnet_SchemaVersions    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_SchemaVersions(
	Feature nvarchar(128) NOT NULL,
	CompatibleSchemaVersion nvarchar(128) NOT NULL,
	IsCurrentVersion bit NOT NULL,
PRIMARY KEY CLUSTERED 
(
	Feature,
	CompatibleSchemaVersion
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table aspnet_Users    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_Users(
	ApplicationId char(32) NOT NULL,
	UserId char(32) NOT NULL,
	UserName nvarchar(256) NOT NULL,
	LoweredUserName nvarchar(256) NOT NULL,
	MobileAlias nvarchar(16) NULL,
	IsAnonymous bit NOT NULL,
	LastActivityDate datetime NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	UserId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table aspnet_UsersInRoles    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_UsersInRoles(
	UserId char(32) NOT NULL,
	RoleId char(32) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	UserId,
	RoleId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table aspnet_WebEvent_Events    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE aspnet_WebEvent_Events(
	EventId char(32) NOT NULL,
	EventTimeUtc datetime NOT NULL,
	EventTime datetime NOT NULL,
	EventType nvarchar(256) NOT NULL,
	EventSequence decimal(19, 0) NOT NULL,
	EventOccurrence decimal(19, 0) NOT NULL,
	EventCode int NOT NULL,
	EventDetailCode int NOT NULL,
	Message nvarchar(1024) NULL,
	ApplicationPath nvarchar(256) NULL,
	ApplicationVirtualPath nvarchar(256) NULL,
	MachineName nvarchar(256) NOT NULL,
	RequestUrl nvarchar(1024) NULL,
	ExceptionType nvarchar(256) NULL,
	Details text NULL,
PRIMARY KEY CLUSTERED 
(
	EventId
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););TEXTIMAGE_;/****** Object:  Table BeaconToObjectAssignment    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE BeaconToObjectAssignment(
	SNo int AUTO_INCREMENT NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL,
	ObjectDeviceID int NOT NULL,
	ObjectID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (SNo););/****** Object:  Table CarBodyTypeDictionary    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE CarBodyTypeDictionary(
	CarBodyTypeID int AUTO_INCREMENT NOT NULL,
	CarBodyType nvarchar(50) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (CarBodyTypeID););/****** Object:  Table CarColorDictionary    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE CarColorDictionary(
	CarColorID int AUTO_INCREMENT NOT NULL,
	CarColor nvarchar(50) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (CarColorID););/****** Object:  Table CarInfo    Script Date: 02.01.2020 12:23:13 ******/
CREATE TABLE CarInfo(
	CarID int AUTO_INCREMENT NOT NULL,
	CarColorID int NOT NULL,
	CarPhoto char(32) NULL,
	CarManufacturer nvarchar(32) NOT NULL,
	CarModel nvarchar(32) NOT NULL,
	CarReleaseYear char(10) NULL,
	CarBodyTypeID int NULL,
	VIN nvarchar(32) NOT NULL,
	CarCaller nvarchar(32) NULL,
	CarRegNumber nvarchar(16) NOT NULL,
	CarEngineNumber nvarchar(16) NOT NULL,
	CarChassisNumber nvarchar(16) NOT NULL,
	ObjectID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	HasCamera tinyint NOT NULL,
	DriverFName nvarchar(20) NOT NULL,
	DriverMName nvarchar(20) NOT NULL,
	DriverLName nvarchar(20) NOT NULL,
	DriverPhone nvarchar(15) NOT NULL,
	FuelTankVolume int NOT NULL,
	InstallLocation nvarchar(128) NULL,
 CONSTRAINT PK_CarInfo PRIMARY KEY NONCLUSTERED 
(
	CarID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table CarSensor    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE CarSensor(
	SensorID int AUTO_INCREMENT NOT NULL,
	SNo int NOT NULL,
	CarSensorTypeID int NOT NULL,
	RegDate datetime NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	SensorXMLParam text NULL,
 PRIMARY KEY (SensorID););TEXTIMAGE_;/****** Object:  Table CarSensorTypeDictionary    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE CarSensorTypeDictionary(
	CarSensorTypeID int AUTO_INCREMENT NOT NULL,
	CarSensorType varchar(32) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (CarSensorTypeID););/****** Object:  Table CarToGroup    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE CarToGroup(
	CarToGroupID int AUTO_INCREMENT NOT NULL,
	ObjectID int NOT NULL,
	GroupID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (CarToGroupID););/****** Object:  Table CarToService    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE CarToService(
	ID int AUTO_INCREMENT NOT NULL,
	ObjectID int NOT NULL,
	ServiceID int NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ID););/****** Object:  Table ClientToService    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE ClientToService(
	ID int AUTO_INCREMENT NOT NULL,
	OwnerID int NOT NULL,
	ServiceID int NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	HistoryOnID int NOT NULL,
	HistoryOffID int NULL,
	ServiceParams text NULL,
 PRIMARY KEY (ID););TEXTIMAGE_;/****** Object:  Table Command    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE Command(
	CommandID int AUTO_INCREMENT NOT NULL,
	CommandActionID int NOT NULL,
	CommandOnlineID int NOT NULL,
	CommandOccuranceDate datetime NOT NULL,
	CommandReadDate datetime NULL,
	Ackowledged bit NOT NULL,
	SenderComment nvarchar(200) NULL,
	UserMapID int NOT NULL,
	IMEI varchar(50) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (CommandID););/****** Object:  Table CommandAction    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE CommandAction(
	CommandActionID int AUTO_INCREMENT NOT NULL,
	CommandTypeID int NOT NULL,
	SNo int NOT NULL,
	ActionID int NOT NULL,
	IsActual bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (CommandActionID););/****** Object:  Table CommandTypeDictionary    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE CommandTypeDictionary(
	CommandTypeID int AUTO_INCREMENT NOT NULL,
	ObjectDeviceTypeID int NOT NULL,
	CommandDescription char(64) NOT NULL,
	CommandCode int NOT NULL,
	CommandArg_1 int NULL,
	CommandArg_2 int NULL,
	CommandText nvarchar(500) NULL,
	IsActual bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	DefaultActionID int NULL,
 PRIMARY KEY (CommandTypeID););/****** Object:  Table DeliveryTypeDictionary    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE DeliveryTypeDictionary(
	DeliveryTypeID int AUTO_INCREMENT NOT NULL,
	DeliveryTypeName nvarchar(50) NOT NULL,
	HasSound bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (DeliveryTypeID););/****** Object:  Table DeviceHistory    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE DeviceHistory(
	ID int AUTO_INCREMENT NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL,
	ObjectDeviceID int NOT NULL,
	OwnerID int NULL,
	UserMapID int NOT NULL,
	Comment nvarchar(250) NULL,
	DistributorID int NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	DistributorStoreID int NULL,
	ObjectID int NULL,
	IsBroken bit NOT NULL,
 PRIMARY KEY (ID););/****** Object:  Table DeviceLog    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE DeviceLog(
	DeviceLogID int AUTO_INCREMENT NOT NULL,
	ObjectDeviceID int NOT NULL,
	UserName nvarchar(32) NOT NULL,
	ActionDate datetime NOT NULL,
	Comment nvarchar(2048) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (DeviceLogID););/****** Object:  Table DeviceStore    Script Date: 02.01.2020 12:23:14 ******/
CREATE TABLE DeviceStore(
	DeviceStoreId int AUTO_INCREMENT NOT NULL,
	OwnerID int NULL,
	DeviceID int NOT NULL,
	DistributorStoreID int NULL,
	IsBroken bit NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (DeviceStoreId);,
UNIQUE NONCLUSTERED 
(
	DeviceID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table DeviceToObjectAssignment    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE DeviceToObjectAssignment(
	SNo int AUTO_INCREMENT NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL,
	ObjectDeviceID int NOT NULL,
	ObjectID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (SNo););/****** Object:  Table Distributor    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE Distributor(
	DistributorID int AUTO_INCREMENT NOT NULL,
	DistributorRootID int NULL,
	DistributorTitle nvarchar(50) NOT NULL,
	DistributorContactName nvarchar(80) NULL,
	Phone char(20) NULL,
	Address nvarchar(250) NULL,
	Mail varchar(50) NULL,
	RegDate datetime NULL,
	IsActive bit NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (DistributorID););/****** Object:  Table DistributorStoreDictionary    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE DistributorStoreDictionary(
	DistributorStoreID int AUTO_INCREMENT NOT NULL,
	DistrStoreTitle nvarchar(50) NOT NULL,
	DistrStoreComment nvarchar(200) NULL,
	DistributorID int NOT NULL,
	IsActive bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (DistributorStoreID););/****** Object:  Table EventCodeDictionary    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE EventCodeDictionary(
	EventCodeID int NOT NULL,
	EventCodeDescription nvarchar(200) NOT NULL,
	IsActive bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (EventCodeID););/****** Object:  Table EventGroup    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE EventGroup(
	EventGroupID int AUTO_INCREMENT NOT NULL,
	EventGroupName nvarchar(100) NOT NULL,
	IsActive bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (EventGroupID););/****** Object:  Table EventTranslator    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE EventTranslator(
	ETID int AUTO_INCREMENT NOT NULL,
	EventCodeID int NOT NULL,
	SNo int NOT NULL,
	AlertTypeID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ETID););/****** Object:  Table GeneratedAlertStatus    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE GeneratedAlertStatus(
	IMEI varchar(50) NOT NULL,
	NoSignalStatus bit NULL,
	NoCoordStatus bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	Mask int NULL
);/****** Object:  Table GlobalSettings    Script Date: 02.01.2020 12:23:15 ******/
CREATE TABLE GlobalSettings(
	SettingsID int AUTO_INCREMENT NOT NULL,
	SettingName nvarchar(50) NOT NULL,
	StrSettingVal nvarchar(250) NULL,
	IntSettingVal int NULL,
	DateSettingVal datetime NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (SettingsID););/****** Object:  Table GuardAssignment    Script Date: 02.01.2020 12:23:29 ******/
CREATE TABLE GuardAssignment(
	GuardAssignmentID int AUTO_INCREMENT NOT NULL,
	GuardID int NOT NULL,
	UserMapID int NOT NULL,
	StartDate datetime NOT NULL,
	FinishDate datetime NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (GuardAssignmentID););/****** Object:  Table GuardOrder    Script Date: 02.01.2020 12:23:29 ******/
CREATE TABLE GuardOrder(
	GuardOrderID int AUTO_INCREMENT NOT NULL,
	Name nvarchar(50) NOT NULL,
	RegDate datetime NOT NULL,
	IsActual bit NOT NULL,
	DistributorID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (GuardOrderID););/****** Object:  Table GuardOrderList    Script Date: 02.01.2020 12:23:29 ******/
CREATE TABLE GuardOrderList(
	GuardOrderListID int AUTO_INCREMENT NOT NULL,
	GuardID int NOT NULL,
	CarID int NOT NULL,
	FromDate datetime NOT NULL,
	ToDate datetime NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (GuardOrderListID););/****** Object:  Table HistoryAction    Script Date: 02.01.2020 12:23:29 ******/
CREATE TABLE HistoryAction(
	ActionID int AUTO_INCREMENT NOT NULL,
	Name nchar(200) NOT NULL,
 PRIMARY KEY (ActionID););/****** Object:  Table HistoryDetails    Script Date: 02.01.2020 12:23:29 ******/
CREATE TABLE HistoryDetails(
	ID int AUTO_INCREMENT NOT NULL,
	UserMapID int NOT NULL,
	Comment nvarchar(250) NULL,
	TVestion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ID););/****** Object:  Table HistoryDictionary    Script Date: 02.01.2020 12:23:29 ******/
CREATE TABLE HistoryDictionary(
	DictionaryID int AUTO_INCREMENT NOT NULL,
	PageID int NOT NULL,
	ActionID int NOT NULL,
	Description nvarchar(200) NULL,
 PRIMARY KEY (DictionaryID););/****** Object:  Table HistoryEvent    Script Date: 02.01.2020 12:23:29 ******/
CREATE TABLE HistoryEvent(
	EventID int AUTO_INCREMENT NOT NULL,
	DictionaryID int NULL,
	UserID char(32) NOT NULL,
	EventDate datetime NOT NULL,
 PRIMARY KEY (EventID););/****** Object:  Table HistoryEventOption    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE HistoryEventOption(
	EventOptionID int NOT NULL,
	Options nvarchar(200) NULL,
	ReportID int NULL,
 PRIMARY KEY (EventOptionID););/****** Object:  Table HistoryPage    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE HistoryPage(
	PageID int AUTO_INCREMENT NOT NULL,
	Name nchar(200) NOT NULL,
 PRIMARY KEY (PageID););/****** Object:  Table LockeyUser    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE LockeyUser(
	OwnerID int NULL,
	DistributorID int NULL,
	UserMapID int AUTO_INCREMENT NOT NULL,
	UserID char(32) NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	MiddleName nvarchar(50) NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	PhoneNumber varchar(32) NULL,
 PRIMARY KEY (UserMapID););/****** Object:  Table MessageQueue    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE MessageQueue(
	MessageID int AUTO_INCREMENT NOT NULL,
	AlertID int NOT NULL,
	SubscriptionID int NOT NULL,
	CreationDate datetime NOT NULL,
	DeliveryDate datetime NULL,
	ConfirmDate datetime NULL,
	DeliveryTypeID int NOT NULL,
	ObjectID int NOT NULL,
	UserMapID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (MessageID););/****** Object:  Table Object    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE Object(
	ObjectID int AUTO_INCREMENT NOT NULL,
	ObjectTypeID int NOT NULL,
	OwnerID int NOT NULL,
	RegDate datetime NULL,
	Properties text NULL,
	IsActive bit NOT NULL,
	LastUpdated datetime NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	ObjectName nvarchar(250) NOT NULL,
 PRIMARY KEY (ObjectID););TEXTIMAGE_;/****** Object:  Table ObjectActivityLog    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE ObjectActivityLog(
	ObjectActivityID int AUTO_INCREMENT NOT NULL,
	IsActive bit NOT NULL,
	Date datetime NOT NULL,
	ObjectID int NOT NULL,
	UserMapID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ObjectActivityID););/****** Object:  Table ObjectDevice    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE ObjectDevice(
	ObjectDeviceID int AUTO_INCREMENT NOT NULL,
	CustomDeviceID int NOT NULL,
	IMEI varchar(50) NOT NULL,
	SIM varchar(50) NOT NULL,
	IsActive bit NOT NULL,
	ObjectDeviceTypeID int NOT NULL,
	ActivationRequired bit NULL,
	ActivationKey nvarchar(20) NULL,
	ObjectHasGPRS bit NOT NULL,
	ICounter int NOT NULL,
	DataServerIP varchar(50) NULL,
	DataServerPort int NULL,
	DataPeriod int NULL,
	LastContact datetime NULL,
	ObjectDeviceRegDate datetime NULL,
	GPRSpwd nvarchar(50) NOT NULL,
	HasVideo tinyint NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	SIMCardNum varchar(32) NULL,
	VInsertion varchar(16) NULL,
	DeviceComment nvarchar(200) NULL,
 PRIMARY KEY (ObjectDeviceID);,
UNIQUE NONCLUSTERED 
(
	IMEI
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);,
UNIQUE NONCLUSTERED 
(
	CustomDeviceID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table ObjectDeviceSnapShot    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE ObjectDeviceSnapShot(
	DeviceSnapShotID int AUTO_INCREMENT NOT NULL,
	PositionLatitude float NOT NULL,
	PositionLongitude float NOT NULL,
	PositionSpeed float NULL,
	PositionAltitude int NULL,
	PositionAddress varchar(150) NULL,
	PositionOccuranceDate datetime NOT NULL,
	PositionEntryDate datetime NOT NULL,
	IMEI varchar(50) NOT NULL,
	PositionBortdate datetime NOT NULL,
	PositionLastOccuranceDate datetime NOT NULL,
	PositionLastBortdate datetime NOT NULL,
	PositionLastEntryDate datetime NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	Course smallint NOT NULL,
 PRIMARY KEY (DeviceSnapShotID););/****** Object:  Table ObjectDeviceTypeDictionary    Script Date: 02.01.2020 12:23:30 ******/
CREATE TABLE ObjectDeviceTypeDictionary(
	ObjectDeviceTypeID int AUTO_INCREMENT NOT NULL,
	DeviceType nvarchar(20) NOT NULL,
	DeviceTypeVersion char(10) NULL,
	DeviceTypeSWVersion char(10) NULL,
	IsActual bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	FunctionFlags int NOT NULL,
 PRIMARY KEY (ObjectDeviceTypeID););/****** Object:  Table ObjectImage    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ObjectImage(
	ImageID char(32) NOT NULL,
	ObjectPicture BLOB NULL,
	LastUpdated datetime NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ImageID););TEXTIMAGE_;/****** Object:  Table ObjectStatus    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ObjectStatus(
	ObjectStatusID int AUTO_INCREMENT NOT NULL,
	ObjectID int NOT NULL,
	StatusTypeID int NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NULL,
	Comment nvarchar(150) NULL,
	UserMapID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ObjectStatusID););/****** Object:  Table ObjectStatusSnapShot    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ObjectStatusSnapShot(
	ObjectStatusSnapShotID int AUTO_INCREMENT NOT NULL,
	OccuranceDate datetime NOT NULL,
	StatusTypeID int NOT NULL,
	EntryDate datetime NULL,
	IMEI varchar(50) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ObjectStatusSnapShotID););/****** Object:  Table ObjectToRoute    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ObjectToRoute(
	RouteToObjectID int AUTO_INCREMENT NOT NULL,
	RouteID int NOT NULL,
	RouteExpireTime datetime NOT NULL,
	ObjectID int NOT NULL,
	UserMapID int NOT NULL,
	RegDate datetime NOT NULL,
	Calendar text NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (RouteToObjectID););TEXTIMAGE_;/****** Object:  Table ObserveGroups    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ObserveGroups(
	ID int AUTO_INCREMENT NOT NULL,
	OwnerID int NOT NULL,
	GroupList text NULL,
 PRIMARY KEY (ID););TEXTIMAGE_;/****** Object:  Table Owner    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE Owner(
	OwnerID int AUTO_INCREMENT NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	DistributorID int NOT NULL,
	MiddleName nvarchar(50) NULL,
	LastName varchar(50) NOT NULL,
	Address nvarchar(250) NULL,
	HomePhone nvarchar(50) NULL,
	MobilePhone nvarchar(50) NULL,
	WorkPhone nvarchar(50) NULL,
	RegDate datetime NULL,
	OwnerMail nvarchar(50) NULL,
	Organization nvarchar(50) NULL,
	OwnerTypeDictionaryID int NOT NULL,
	IsActive bit NOT NULL,
	CodeWord nvarchar(50) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (OwnerID););/****** Object:  Table OwnerPaymentInfo    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE OwnerPaymentInfo(
	OwnerPaymentID int AUTO_INCREMENT NOT NULL,
	OwnerID int NOT NULL,
	OwnerPaymentCode nvarchar(50) NOT NULL,
 PRIMARY KEY (OwnerPaymentID););/****** Object:  Table OwnerTypeDictionary    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE OwnerTypeDictionary(
	OwnerTypeDictionaryID int AUTO_INCREMENT NOT NULL,
	OwnerTypeDescription nvarchar(20) NOT NULL,
	IsActual bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (OwnerTypeDictionaryID););/****** Object:  Table ProblemReport    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ProblemReport(
	ProblemID int AUTO_INCREMENT NOT NULL,
	AuthorID int NOT NULL,
	AuthorName nvarchar(128) NOT NULL,
	AuthorPhone nvarchar(50) NULL,
	AuthorMail nvarchar(50) NULL,
	CreationDate datetime NOT NULL,
	ProblemDesc nvarchar(max) NOT NULL,
	ProblemImg varbinary(max) NULL,
	ProblemState int NOT NULL,
	UserClosedID int NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ProblemID););TEXTIMAGE_;/****** Object:  Table ProfileSample    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ProfileSample(
	ID int AUTO_INCREMENT NOT NULL,
	Title varchar(64) NOT NULL,
	DefaultValuesXML text NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ID););TEXTIMAGE_;/****** Object:  Table ReportArchive    Script Date: 02.01.2020 12:23:31 ******/
CREATE TABLE ReportArchive(
	ReportID int AUTO_INCREMENT NOT NULL,
	FromDate datetime NOT NULL,
	ToDate datetime NOT NULL,
	CreationDate datetime NOT NULL,
	MinWorkTime real NOT NULL,
	VersionReport int NOT NULL,
 PRIMARY KEY (ReportID););/****** Object:  Table ReportArchiveData    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE ReportArchiveData(
	ReportDataID int AUTO_INCREMENT NOT NULL,
	ClientID int NULL,
	ReportID int NULL,
	CountCars int NOT NULL,
	CountNotActiveCars int NULL,
	CountSuspendCars int NOT NULL,
	CountNotWorkingCars int NOT NULL,
 PRIMARY KEY (ReportDataID););/****** Object:  Table Route    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE Route(
	RouteID int AUTO_INCREMENT NOT NULL,
	RouteDescription char(10) NOT NULL,
	OwnerID int NULL,
	IsActive bit NOT NULL,
	LastUpdated datetime NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (RouteID););/****** Object:  Table RouteDetails    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE RouteDetails(
	RouteID int AUTO_INCREMENT NOT NULL,
	Points text NOT NULL,
	Stops text NOT NULL,
	IsActive bit NOT NULL,
	Name nvarchar(64) NOT NULL,
	TimeInMinutes int NOT NULL,
	OwnerID int NOT NULL,
 PRIMARY KEY (RouteID););TEXTIMAGE_;/****** Object:  Table Services    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE Services(
	ID int AUTO_INCREMENT NOT NULL,
	Title nvarchar(64) NOT NULL,
	IsClient bit NOT NULL,
	IsActive bit NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ID););/****** Object:  Table SmsHistory    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE SmsHistory(
	HistoryID int AUTO_INCREMENT NOT NULL,
	UserName nvarchar(256) NOT NULL,
	SentDate datetime NOT NULL,
	Amount int NOT NULL,
 PRIMARY KEY (HistoryID););/****** Object:  Table StatusTypeDictionary    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE StatusTypeDictionary(
	StatusTypeID int AUTO_INCREMENT NOT NULL,
	StatusDescription nvarchar(150) NULL,
	StatusTitle nvarchar(50) NOT NULL,
	IsActual bit NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (StatusTypeID););/****** Object:  Table Subscription    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE Subscription(
	SubscriptionID int AUTO_INCREMENT NOT NULL,
	Title varchar(64) NOT NULL,
	UserMapID int NOT NULL,
	IsActive bit NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	StartTime time(0) NULL,
	EndTime time(0) NULL,
 PRIMARY KEY (SubscriptionID););/****** Object:  Table SubscriptionDelivery    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE SubscriptionDelivery(
	SubscriptionID int NOT NULL,
	DeliveryTypeID int NOT NULL,
	PlaySound bit NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 CONSTRAINT SubscriptionDelivery_PK PRIMARY KEY CLUSTERED 
(
	SubscriptionID,
	DeliveryTypeID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table SubscriptionEvent    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE SubscriptionEvent(
	SubscriptionID int NOT NULL,
	EventGroupID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	EventParam int NULL,
 CONSTRAINT PK_SubscriptionEvent PRIMARY KEY CLUSTERED 
(
	SubscriptionID,
	EventGroupID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table SubscriptionObject    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE SubscriptionObject(
	SubscriptionID int NOT NULL,
	ObjectID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 CONSTRAINT PK_SubscriptionObject PRIMARY KEY CLUSTERED 
(
	SubscriptionID,
	ObjectID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table SubscriptionParams    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE SubscriptionParams(
	SubscriptionID int NOT NULL,
	DeliveryTypeID int NOT NULL,
	Value varchar(3200) NOT NULL,
 CONSTRAINT PK_SubscriptionParams PRIMARY KEY CLUSTERED 
(
	SubscriptionID,
	DeliveryTypeID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table SubsriptionZoneEvent    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE SubsriptionZoneEvent(
	SubscriptionID int NOT NULL,
	EventGroupID int NOT NULL,
	ZoneID int NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 CONSTRAINT PK_SubscriptionZoneEvent PRIMARY KEY CLUSTERED 
(
	SubscriptionID,
	EventGroupID,
	ZoneID
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON););/****** Object:  Table TmpOrder    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE TmpOrder(
	OrderID int AUTO_INCREMENT NOT NULL,
	Operator varchar(15) NOT NULL,
	PhoneNumber varchar(15) NOT NULL,
 PRIMARY KEY (OrderID););/****** Object:  Table TmpSim    Script Date: 02.01.2020 12:23:32 ******/
CREATE TABLE TmpSim(
	ID int AUTO_INCREMENT NOT NULL,
	Operator varchar(15) NOT NULL,
	PhoneNumber varchar(15) NOT NULL,
	SIM varchar(24) NOT NULL,
 PRIMARY KEY (ID););/****** Object:  Table UserActionLog    Script Date: 02.01.2020 12:23:33 ******/
CREATE TABLE UserActionLog(
	UserActionLogID int AUTO_INCREMENT NOT NULL,
	UserID varchar(64) NOT NULL,
	ActionType varchar(8) NOT NULL,
	ActionDate datetime NOT NULL,
	ObjectID int NULL,
	ObjectClassName nvarchar(50) NULL,
	ChangesInfo nvarchar(max) NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (UserActionLogID););TEXTIMAGE_;/****** Object:  Table UserAgreement    Script Date: 02.01.2020 12:23:33 ******/
CREATE TABLE UserAgreement(
	UserAgrID int AUTO_INCREMENT NOT NULL,
	UserMapID int NOT NULL,
	AgrDate datetime NOT NULL,
	Accepted bit NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (UserAgrID););/****** Object:  Table VehicleToZone    Script Date: 02.01.2020 12:23:33 ******/
CREATE TABLE VehicleToZone(
	VehicleToZoneID int AUTO_INCREMENT NOT NULL,
	VehicleID int NOT NULL,
	ZoneID int NOT NULL,
	FromDate datetime NOT NULL,
	ToDate datetime NULL,
	Alerted bit NOT NULL,
	Calendar text NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (VehicleToZoneID););TEXTIMAGE_;/****** Object:  Table WorkGroup    Script Date: 02.01.2020 12:23:33 ******/
CREATE TABLE WorkGroup(
	GroupID int AUTO_INCREMENT NOT NULL,
	OwnerID int NOT NULL,
	Name char(64) NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (GroupID););/****** Object:  Table Zone    Script Date: 02.01.2020 12:23:33 ******/
CREATE TABLE Zone(
	ZoneID int AUTO_INCREMENT NOT NULL,
	Points text NOT NULL,
	Name nvarchar(64) NOT NULL,
	OwnerID int NULL,
	DistributorID int NULL,
	IsActive bit NOT NULL,
	LastUpdated datetime NOT NULL,
	TVersion timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
 PRIMARY KEY (ZoneID););TEXTIMAGE_;