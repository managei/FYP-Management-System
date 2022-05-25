# FYP-Management-System_DB-Final-Project
This project tries to develop a web-based system that facilitates final year projects
DB Project
Final Year Management System:

## Figma
link

## objective: 
deisgn a comprehensive web-systems for facilitate multiple types of users

## Types of Users:
- FYP Committee
- Project Supervisors
- Panel Members
- Project Group Members

- Each user must have an account
- Only for FYP1

## Registering students into FYP1
- group member names,
- project title
- supervisor
- co-supervisor

- The group members cannot be changed after the creation (no possible updates)
- User interface for every type of user
- 4 views to be created

## FYP Committee View
- main role
- access to those who are part of FYP Committee
- specify new users
- specify users’ roles
- grant privileges to users

- create students, faculty
- make committee panels from faculty
- choose supervisors  

- see the students registered
- group members, supervisors, project details
- check wokload of supervisors 
- one supervisor can only supervise 6 FYP
- otherwise the workload is shifted
- send notification to supervisors to notify and confirm with the students they are taking
- make table of notifications
- create Panel of faculty members
- Panels evaluate FYPs
- evaluation form of panel members
- marks given in the form are added and the grades are generated accordingly
- the committe can easily identify which panel members evaluations are missing
- and which evaluations are not presented by the students
- assign deadlines of submissions or evaluations, and other roles should view the deadlines
- has full access to the missing evaluations, and FYPs
- generate 3 reports:
1) Missing Evaluation report
2) FYPs Supervised by Faculty Report
3) Grades Report

## Panel Members View
- view only for faculty members
- view FYPs part of their panel
- view group members of FYP
- view description of a specific FYP
- mandatory that every panel member present should fill the evaluation form
- if not it should show missing evaluations, and the panel member missing should fill this 
- panel member should only search FYPs that are part of his/her panel
- One faculty member can not be part of multiple panels

## Project Supervisor Interface
- view only for faculty members who are supervising FYPs
- one cannot supervise more than 6 FYPs
- can see active FYPs
- can see which FYPs are being supervised currently
- can see details of those FYPs like group info, assigned panels, and grades at the end of the evaluation
- supervisor can view the suggestions and the comments of the panel members. 
- supervisor should give reviews on FYPs otherwise it should display missing review and give it later on 

## Student Interface
- view only for students who registered themselves for FYP1
- student can see his or her group members
- can see project title and administration
- can see assigned supervisor
- can see the panels that will evaluate their FYP
- view the reviews/suggestions names of the panel members should be hidden and not visible to the student
- view the deadline of the presentations, submissions will be visible to the student
- students can view the grades when finalised

## Create Audit Trail
https://www.sqlshack.com/various-techniques-to-audit-sql-server-databases/
https://docs.microsoft.com/en-us/sql/relational-databases/security/permissions-database-engine?view=sql-server-ver16

## Requirements
- ERD
- Schema Diagram
- SQL queries and C# code
