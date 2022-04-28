// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace students.data 
{
public class studentContext : DbContext
{
 public studentContext(DbContextOptions<studentContext>options)
 :base(options) 
 {

 }
 public DbSet<student> students {get; set;}

 
}
}