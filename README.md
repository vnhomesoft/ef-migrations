## Database
### Entities
1. Student
2. Subject
3. StudentSubject (relationship between Student and Subject)

### Relationship
- Student - Subject : n-n
- Class -
- Student - Mark : 1-n

### Migrations
- Development env. : Changes is apply automatically
- Staging, Production env. : use CLI command to apply change and integrate with CI tool
```
# Skip build
dotnet ef database update -v --no-build
```