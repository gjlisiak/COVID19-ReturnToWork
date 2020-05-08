/****** Object:  Table [dbo].[QuarantineInfo]    Script Date: 4/29/2020 3:39:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuarantineInfo] (
	[UserId] [nvarchar](50) NOT NULL,
	[Cycle] [int] NULL,
	[QuarStartDate] [datetime] NULL,
	[QuarMidpointDate] [datetime] NULL,
	[QuarEndDate] [datetime] NULL,
	[DateOfEntry] [datetime] default CURRENT_TIMESTAMP,
	[SymptomFever] [bit] NULL,
	[SymptomShortnessOfBreath] [bit] NULL,
	[SymptomCough] [bit] NULL,
	[SymptomRunningNose] [bit] NULL,
	[SymptomSoreThroat] [bit] NULL,
	[SymptomChills] [bit] NULL,
	[SymptomDizziness] [bit] NULL,
	[SymptomAbdomenPain] [bit] NULL,
	[SymptomDiarrhea] [bit] NULL,
	[SymptomFatigue] [bit] NULL,
	[SymptomOther] [nvarchar](1500) NULL,
	[Temperature] decimal(5,2) NULL,
	[O2Saturation] decimal(5,2) NULL,
	[AntibodyTestDate] [datetime] NULL,
	[AntibodyTestResult] [bit] NULL,
	[RequestRTW] [datetime] NULL,
	[ApprovalRTW] [bit] NULL,
	[TeamsCallInitiated] [bit] NULL,
	[TeamsCallCompleted] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScreeningInfo]    Script Date: 4/29/2020 3:39:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreeningInfo](
	[UserId] [nvarchar](50) NOT NULL,
	[DateOfEntry] [datetime] default CURRENT_TIMESTAMP,
	[UserExposed] [bit] NULL,
	[ExposureDirect] [bit] NULL,
	[ExposureIndirect] [bit] NULL,
	[ExposureMultiple] [bit] NULL,
	[ExposureNotsure] [bit] NULL,
	[ExposureDate] [datetime] NULL,
	[SymptomsYesNo] [bit] NULL,
	[SymptomFever] [bit] NULL,
	[SymptomShortnessOfBreath] [bit] NULL,
	[SymptomCough] [bit] NULL,
	[SymptomRunningNose] [bit] NULL,
	[SymptomSoreThroat] [bit] NULL,
	[SymptomChills] [bit] NULL,
	[SymptomDizziness] [bit] NULL,
	[SymptomAbdomenPain] [bit] NULL,
	[SymptomOther] [nvarchar](1500) NULL,
	[GUID] [nvarchar](50) NULL,
	[QuarantineRequired] [bit] NOT NULL
) ON [PRIMARY] 
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 4/29/2020 3:39:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [nvarchar](50) NOT NULL,
	[UserType] [nvarchar](50) NULL default 'Employee',
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[MobileNumber] [nvarchar](15) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[StreetAddress1] [nvarchar](50) NULL,
	[StreetAddress2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL default 'United States',
	[ZipCode] [nvarchar](30) NULL,
	[TeamsAddress] [nvarchar](1500) NULL,
	[TwilioAddress] [nvarchar](1500) NULL
) ON [PRIMARY] 
GO
/****** Object:  Table [dbo].[UserUnderlyingInfo]    Script Date: 4/29/2020 3:39:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUnderlyingInfo](
	[UserId] [nvarchar](50) NOT NULL,
	[HeartDisease] [bit] NULL,
	[Asthma] [bit] NULL,
	[LungProblems] [bit] NULL,
	[Cancer] [bit] NULL,
	[Diabetes] [bit] NULL,
	[Chemotherapy] [bit] NULL,
	[Arthritis] [bit] NULL,
	[isThermometerHandy] [bit] NULL,
	[isO2SatMonitorHandy] [bit] NULL
) ON [PRIMARY]
GO
