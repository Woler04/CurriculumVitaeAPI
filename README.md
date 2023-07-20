# Curriculum Vitae Builder API Documentaion
This repository contains an API(Application programming interface) for our project Curriculum Vitae (Builder) 
made for AIBEST Academy 2023

## Set up
Unfortunately, our API is not hosted anywhere so it has to be run locally to be used
After downloading or cloning and opening the solution you need to

1. Get a valid connection string to database and set it in the appsettings.json
```
 "ConnectionStrings": {
   "DefaultConnection": "Data Source=YOURCONNECTIONSTRING"
 }
```

2. Then run the "update-database" command in the Package Manager Console so the migrations be applied
3. There is no seed for the database BUT that is an excellent opportunity to try reaching an endpoint

## End Points
### User
User DTO(data transfer object)(can become easy JSON)
```
{
id	integer($int32)
username	string
nullable: true
email	string
nullable: true
password	string
nullable: true
}
```
Get all users

GET /api/User

Create a new user

POST /api/User

Get a specific user

GET /api/User/{userId}

Update a specific user

PUT /api/User/{userId}

Delete a specific user

DELETE /api/User/{userId}

Get resumes associated with a user

GET /api/User/{userId}/resumes

### Resume
Resume DTO
```
{
resumeId	integer($int32)
title	string
nullable: true
creationTime	string($date-time)
lastModifiedTime	string($date-time)
}
```
Get all resumes

GET /api/Resume

Create a new resume

POST /api/Resume

Get a specific resume

GET /api/Resume/{resumeId}

Update a resume

PUT /api/Resume/{resumeId}

Delete a resume

DELETE /api/Resume/{resumeId}

Get resume's associated user

GET /api/Resume/{resumeId}/user

Get resume's skills

GET /api/Resume/{resumeId}/skills

Get resume's template

GET /api/Resume/{resumeId}/template

Get resume's locations

GET /api/Resume/{resumeId}/locations

Get resume's languages

GET /api/Resume/{resumeId}/languages

Get resume's certificates

GET /api/Resume/{resumeId}/certificates

Get resume's personal info

GET /api/Resume/{resumeId}/personalInfo

Get resume's educations

GET /api/Resume/{resumeId}/educations

Get resume's experiences

GET /api/Resume/{resumeId}/experiences

### Personal Info
Personal Info DTO
```
{
personalinfoId	integer($int32)
fullName	string
nullable: true
address	string
nullable: true
phoneNumber	string
nullable: true
email	string
nullable: true
}
```
Get all personal info

GET /api/PersonalInfo

Create new personal info

POST /api/PersonalInfo

Get specific personal info

GET /api/PersonalInfo/{personalInfoId}

Update specific personal info

PUT /api/PersonalInfo/{personalInfoId}

Delete specific personal info

DELETE /api/PersonalInfo/{personalInfoId}

Update personal info for a resume

PUT /api/PersonalInfo/{resumeId}


### Experience
Experience DTO
```
{
experienceId	integer($int32)
companyName	string
nullable: true
position	string
nullable: true
startDate	string($date-time)
endDate	string($date-time)
description	string
nullable: true
}
```
Get all experiences

GET /api/Experience

Create a new experience

POST /api/Experience

Get a specific experience

GET /api/Experience/{experienceId}

Update a specific experience

PUT /api/Experience/{experienceId}

Delete a specific experience

DELETE /api/Experience/{experienceId}

### Education
Education DTO
```
{
educationId	integer($int32)
institutionName	string
nullable: true
degree	string
nullable: true
fieldOfStudy	string
nullable: true
startDate	string($date-time)
endDate	string($date-time)
}
```
Get all educations

GET /api/Education

Create a new education

POST /api/Education

Get a specific education

GET /api/Education/{educationId}

Update a specific education

PUT /api/Education/{educationId}

Delete a specific education

DELETE /api/Education/{educationId}

### Certificate 
Certificate DTO
```
{
certificateId	integer($int32)
certificateName	string
nullable: true
issuingOrganization	string
nullable: true
issueDate	string($date-time)
}
```

Get all certificates

GET /api/Certificate

Create a new certificate

POST /api/Certificate

Get a specific certificate

GET /api/Certificate/{certificateId}

Update a specific certificate

PUT /api/Certificate/{certificateId}

Search for resume using a keyword for certficate title (that can be used for sorting out from reqired skill certificate)

GET /api/Certificate/search/{keyword}

Delete a specific certificate

DELETE /api/Certificate/{certificateId}

## Those are with dynamic joined tables so there are special endpoints for associating

### Template
Template DTO
```
{
languageId	integer($int32)
languageName	string
nullable: true
level	string
nullable: true
}
```
Get all templates

GET /api/Template

Create a new template

POST /api/Template

Get a specific template

GET /api/Template/{templateId}

Update a template

PUT /api/Template/{templateId}

Delete a template

DELETE /api/Template/{templateId}

Get resumes using a template

GET /api/Template/{templateId}/resumes

Associate a template with a resume

POST /api/Template/{templateId}&&{resumeId}

Remove association between a template and a resume

DELETE /api/Template/{templateId}&&{resumeId}

### Skill
Skill DTO
```
{
skillId	integer($int32)
skillName	string
nullable: true
}
```
Get all skills

GET /api/Skill

Create a new skill

POST /api/Skill

Get a specific skill

GET /api/Skill/{skillId}

Update a skill

PUT /api/Skill/{skillId}

Delete a skill

DELETE /api/Skill/{skillId}

Get resumes associated with a skill (can be used for sorting out specific required skill)

GET /api/Skill/{skillId}/resumes

Associate a skill with a resume

POST /api/Skill/{skillId}&&{resumeId}

Remove association between a skill and a resume

DELETE /api/Skill/{skillId}&&{resumeId}

### Location
Get all locations
```
{
locationId	integer($int32)
city	string
nullable: true
state	string
nullable: true
country	string
nullable: true
}
```
GET /api/Location

Create a new location

POST /api/Location

Get a specific location

GET /api/Location/{locationId}

Update a specific location

PUT /api/Location/{locationId}

Delete a specific location

DELETE /api/Location/{locationId}

Search for resumes using a keyword (City or State or Country)

GET /search/{keyword}

Get resumes associated with a location

GET /api/Location/{locationId}/resumes

Associate a location with a resume

POST /api/Location/{locationId}&&{resumeId}

Remove association between a location and a resume

DELETE /api/Location/{locationId}&&{resumeId}

### Language
Language DTO
```
{
languageId	integer($int32)
languageName	string
nullable: true
level	string
nullable: true
}
```
Get all languages

GET /api/Language

Create a new language

POST /api/Language

Get a specific language

GET /api/Language/{languageId}

Update a specific language

PUT /api/Language/{languageId}

Delete a specific language

DELETE /api/Language/{languageId}

Get resumes associated with a language

GET /{languageId}/resumes

Associate a language with a resume

POST /api/Language/{languageId}&&{resumeId}

Remove association between a language and a resume

DELETE /api/Language/{languageId}&&{resumeId}









