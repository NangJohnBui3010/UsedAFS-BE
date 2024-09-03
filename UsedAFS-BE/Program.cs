using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using UsedAFS_BE.Entities;

var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

using var db = new CoreContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create DEMO
Console.WriteLine("Inserting a new person");
var newPerson = new PersonEntity
{
    FirstName = "Timothy",
    MiddleName = "Thanh",
    LastName = "Dai",
    AssignedId = "010692833"
};
db.Add(newPerson);
db.SaveChanges();

// Read DEMO
Console.WriteLine("Querying for a person by id");
var person = db.Persons
    .OrderBy(p => p.PersonId)
    .First();

// Update DEMO
Console.WriteLine("Updating the person and adding a book");
person.LastName = "Tran";

var newBook = new BookEntity
{
    ISBN = "000823-28B28",
    Title = "Hardy Brothers 1"
};
person.Books.Add(newBook);
db.SaveChanges();

// Delete DEMO
Console.WriteLine("Delete the person");
db.Remove(person);
db.SaveChanges();