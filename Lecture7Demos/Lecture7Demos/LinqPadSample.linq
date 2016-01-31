<Query Kind="Statements">
  <Connection>
    <ID>aee8728b-38ac-42ab-b49b-dfaf0e9e452f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>AdventureWorks2014</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

string[] names = { "Monkey", "Bear", "Dog", "Cat" };
names.Where(n => n.Contains("o")).Dump();

(from p in Persons where p.LastName.Contains("S") select p).Take(10).Dump();