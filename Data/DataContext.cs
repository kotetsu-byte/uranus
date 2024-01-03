using Microsoft.EntityFrameworkCore;
using Uranus.Models;

namespace Uranus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>()
                .HasKey(pc => new { pc.UserId, pc.CourseId });
            modelBuilder.Entity<UserCourse>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.UserCourses)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserCourse>()
                .HasOne(p => p.Course)
                .WithMany(pc => pc.UserCourses)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Lesson>()
                .HasOne(c => c.Course)
                .WithMany(l => l.Lessons)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Test>()
                .HasOne(c => c.Course)
                .WithMany(t => t.Tests)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doc>()
                .HasOne(l => l.Lesson)
                .WithMany(d => d.Docs)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Video>()
                .HasOne(l => l.Lesson)
                .WithMany(v => v.Videos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Homework>()
                .HasOne(l => l.Lesson)
                .WithMany(h => h.Homeworks)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Material>()
                .HasOne(h => h.Homework)
                .WithMany(m => m.Materials) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course
                    {
                        Id = 1,
                        Name = "Math",
                        Description = "Mathematics is an area of knowledge that includes the topics of numbers, formulas and related structures, shapes and the spaces in which they are contained, and quantities and their changes.",
                        Price = 3000000
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "Physics",
                        Description = "Physics is the natural science of matter, involving the study of matter, its fundamental constituents, its motion and behavior through space and time, and the related entities of energy and force.",
                        Price = 3000000
                    },
                    new Course
                    {
                        Id = 3,
                        Name = "Chemistry",
                        Description = "Chemistry is the scientific study of the properties and behavior of matter.",
                        Price = 3000000
                    },
                    new Course
                    {
                        Id = 4,
                        Name = "Biology",
                        Description = "Biology is the scientific study of life.",
                        Price = 3000000
                    },
                    new Course
                    {
                        Id = 5,
                        Name = "Informatics",
                        Description = "Informatics is the study of computational systems.",
                        Price = 3000000
                    }
            );

            modelBuilder.Entity<Lesson>()
                .HasData(
                    // Math
                    new Lesson
                    {
                        Id = 1,
                        CourseId = 1,
                        Title = "Lesson 1",
                        Info = "In mathematics, a variable (from Latin variabilis, \"changeable\") is a symbol that represents a mathematical object. A variable may represent a number, a vector, a matrix, a function, the argument of a function, a set, or an element of a set.\r\n\r\nAlgebraic computations with variables as if they were explicit numbers solve a range of problems in a single computation. For example, the quadratic formula solves any quadratic equation by substituting the numeric values of the coefficients of that equation for the variables that represent them in the quadratic formula. In mathematical logic, a variable is either a symbol representing an unspecified term of the theory (a meta-variable), or a basic object of the theory that is manipulated without referring to its possible intuitive interpretation.",
                    },
                    new Lesson
                    {
                        Id = 2,
                        CourseId = 1,
                        Title = "Lesson 2",
                        Info = "There are many methods for solving a system of linear equation, one of them is elimination method.\r\n\r\nAs the name suggest in elimination method, we eliminate one of the variables by subtracting one equation from another (or first multiplying one of the equation with some number and then subtracting from other equation).",
                    },
                    new Lesson
                    {
                        Id = 3,
                        CourseId = 1,
                        Title = "Lesson 3",
                        Info = "Terms in an algebraic expression are separated by addition operators and factors are separated by multiplication operators. The numerical factor of a term is called the coefficient. For example, the algebraic expression x2y2+6xy−3\r\n can be thought of as  x2y2+6xy+(−3)\r\n and has three terms. The first term, x2y2\r\n, represents the quantity  1x2y2=1⋅x⋅x⋅y⋅y\r\n where 1 is the coefficient and x and y are the variables. All of the variable factors with their exponents form the variable part of a term.",
                    },
                    new Lesson
                    {
                        Id = 4,
                        CourseId = 1,
                        Title = "Lesson 4",
                        Info = "Combining like terms means to simplify an algebraic expression by counting the variables that are the same. Simply look at each letter in turn and add the numbers in front of them to see how many there are in total.",
                    },
                    new Lesson
                    {
                        Id = 5,
                        CourseId = 1,
                        Title = "Lesson 5",
                        Info = "Distributive property is the algebraic property used to multiply a number with the sum or difference of two or more numbers within a parenthesis. We can say that the distributive property helps in simplifying the problems by breaking the expressions into addition or subtraction of products or vice versa.",
                    },
                    new Lesson
                    {
                        Id = 6,
                        CourseId = 1,
                        Title = "Lesson 6",
                        Info = "In order to understand what “combining like terms” means, let’s get some basic definitions out of the way. First, we have to understand the concept of a term. In algebra, a term can be a number, variable, or product (the multiplication) of a number and variable. Recall, a variable can represent any possible number. Typically in algebra, we use symbols like x or y to represent variables.",
                    },
                    // Physics
                    new Lesson
                    {
                        Id = 7,
                        CourseId = 2,
                        Title = "Lesson 1",
                        Info = "The physical universe is enormously complex in its detail. Every day, each of us observes a great variety of objects and phenomena. Over the centuries, the curiosity of the human race has led us collectively to explore and catalog a tremendous wealth of information. From the flight of birds to the colors of flowers, from lightning to gravity, from quarks to clusters of galaxies, from the flow of time to the mystery of the creation of the universe, we have asked questions and assembled huge arrays of facts. In the face of all these details, we have discovered that a surprisingly small and unified set of physical laws can explain what we observe. As humans, we make generalizations and seek order. We have found that nature is remarkably cooperative—it exhibits the underlying order and simplicity we so value.",
                    },
                    new Lesson
                    {
                        Id = 8,
                        CourseId = 2,
                        Title = "Lesson 2",
                        Info = "Distance is the measurement of paths taken by an object. In simple words, distance is something an object covers in a given time ‘t. ‘ However, displacement is the shortest path taken by an object during its motion. Distance and displacement are two physical quantities that we use in our everyday life.",
                    },
                    new Lesson
                    {
                        Id = 9,
                        CourseId = 2,
                        Title = "Lesson 3",
                        Info = "Average speed is a rate that is a quantity divided by the time taken to get that quantity. SI unit of speed is meters per second. Average speed is calculated by the formula S = d/t, where S equals the average speed, d equals total distance and t equals total time. Average Velocity. Average velocity of an object can be defined as the displacement with regards to the original position divided by the time.",
                    },
                    new Lesson
                    {
                        Id = 10,
                        CourseId = 2,
                        Title = "Lesson 4",
                        Info = "The instantaneous speed is the speed of an object at a particular moment in time. And if you include the direction with that speed, you get the instantaneous velocity. In other words, eight meters per second to the right was the instantaneously velocity of this person at that particular moment in time.",
                    },
                    new Lesson
                    {
                        Id = 11,
                        CourseId = 2,
                        Title = "Lesson 5",
                        Info = "In mechanics, acceleration is the rate of change of the velocity of an object with respect to time. Acceleration is one of several components of kinematics, the study of motion. Accelerations are vector quantities (in that they have magnitude and direction). The orientation of an object's acceleration is given by the orientation of the net force acting on that object.",
                    },
                    new Lesson
                    {
                        Id = 12,
                        CourseId = 2,
                        Title = "Lesson 6",
                        Info = "Kinematics equations are the constraint equations of a mechanical system such as a robot manipulator that define how input movement at one or more joints specifies the configuration of the device, in order to achieve a task position or end-effector location. Kinematics equations are used to analyze and design articulated systems ranging from four-bar linkages to serial and parallel robots.",
                    },
                    // Chemistry
                    new Lesson
                    {
                        Id = 13,
                        CourseId = 3,
                        Title = "Lesson 1",
                        Info = "The average atomic mass (sometimes called atomic weight) of an element is the weighted average mass of the atoms in a naturally occurring sample of the element. Average masses are generally expressed in unified atomic mass units (u), where 1 u is equal to exactly one-twelfth the mass of a neutral atom of carbon-12. Created by Sal Khan. So the atomic mass unit is 1/12th the mass of carbon-12.",
                    },
                    new Lesson
                    {
                        Id = 14,
                        CourseId = 3,
                        Title = "Lesson 2",
                        Info = "Isotopes are two or more types of chemical species or elements that are having same atomic number and the same position in the periodic table of elements. isotopes have different mass numbers or nucleon numbers due to the difference in the number of neutrons in their nuclei. However, all isotopes of a particular element have almost the same chemical properties and different atomic masses, and physical properties.",
                    },
                    new Lesson
                    {
                        Id = 15,
                        CourseId = 3,
                        Title = "Lesson 3",
                        Info = "There are three main types of chemical formulas: empirical, molecular and structural. Empirical formulas show the simplest whole-number ratio of atoms in a compound, molecular formulas show the number of each type of atom in a molecule, and structural formulas show how the atoms in a molecule are bonded to each other.",
                    },
                    new Lesson
                    {
                        Id = 16,
                        CourseId = 3,
                        Title = "Lesson 4",
                        Info = "Elemental analysis can be used to determine the amounts of substances in a mixture. For example, if elemental analysis tells us that a potassium supplement contains 22% K by mass, and we know that the K is present as KCl, we can calculate the grams of KCl in the supplement.",
                    },
                    new Lesson
                    {
                        Id = 17,
                        CourseId = 3,
                        Title = "Lesson 5",
                        Info = "The main difference between shell subshell and orbital is that shells are composed of electrons that share the same principal quantum number and subshells are composed of electrons that share the same angular momentum quantum number whereas orbitals are composed of electrons that are in the same energy level but have different spins.",
                    },
                    new Lesson
                    {
                        Id = 18,
                        CourseId = 3,
                        Title = "Lesson 6",
                        Info = "Periodic trends are specific patterns that are present in the periodic table that illustrate different aspects of a certain element. They were discovered by the Russian chemist Dmitri Mendeleev in the year 1863. Major periodic trends include atomic radius, ionization energy, electron affinity, electronegativity, valency and metallic character.",
                    },
                    // Biology
                    new Lesson
                    {
                        Id = 19,
                        CourseId = 4,
                        Title = "Lesson 1",
                        Info = "Biology is the branch of science that primarily deals with the structure, function, growth, evolution, and distribution of organisms. As a science, it is a methodological study of life and living things. It determines verifiable facts or formulates theories based on experimental findings on living things by applying the scientific method. An expert in this field is called a biologist.",
                    },
                    new Lesson
                    {
                        Id = 20,
                        CourseId = 4,
                        Title = "Lesson 2",
                        Info = "Difference between Elements and Atoms is that Elements are made from atoms and atoms are the smallest part of elements. Elements are the simplest form of any substance and. Atoms are the simplest unit of matter. An element cannot be further broken down by chemical reactions into simpler substances. Elements are made of atoms that have the same atomic number i.e. the nucleus contains the same number of protons.",
                    },
                    new Lesson
                    {
                        Id = 21,
                        CourseId = 4,
                        Title = "Lesson 3",
                        Info = "The hydrogen bonding in water is a vigorous bond between the nearest water molecule containing one Hydrogen atom between two oxygen atoms. Hydrogen bonding is major of two types of intramolecular and intermolecular hydrogen bonding, on the basis of the atoms involved in it. Hydrogen bonding is maximum in solid-state compounds.",
                    },  
                    new Lesson
                    {
                        Id = 22,
                        CourseId = 4,
                        Title = "Lesson 4",
                        Info = "The term “pH” is an abbreviation for the “potential of hydrogen.” pH is a unit of measurement that represents the concentration of hydrogen ions in a solution. This unit was introduced by biochemist Søren Peter Lauritz Sørensen in 1909. It was an easy way to represent the concentration of hydrogen ions in a solution during titrations. When an acid or base is added to water, that compound dissociates into ions.",
                    },
                    new Lesson
                    {
                        Id = 23,
                        CourseId = 4,
                        Title = "Lesson 5",
                        Info = "The smallest objects that the unaided human eye can see are about 0.1 mm long. That means that under the right conditions, you might be able to see an amoeba proteus, a human egg, and a paramecium without using magnification. A magnifying glass can help you to see them more clearly, but they will still look tiny.",
                    },
                    new Lesson
                    {
                        Id = 24,
                        CourseId = 4,
                        Title = "Lesson 6",
                        Info = "The human body is made up of “just” 200–400 cell types, but we (i.e. you and I) have copious amount of each cell types. In fact, there is a mind-bogglingly 10¹⁴ cells (that’s 100 trillion of cells) in a human body, organized into tissues and organs that give rise to life. Cells come in thousands of shapes and sizes, but they are so small that 10,000 of our cells could all fit on the head of a pin. To sustain life, the cells in our body go through 5 x 10¹⁷ biochemical reactions per second (that’s 500 quadrillion every second!). That is why biochemistry plays such a crucial role in understanding cells (and life) and has important medical applications.",
                    },
                    // Informatics
                    new Lesson
                    {
                        Id = 25,
                        CourseId = 5,
                        Title = "Lesson 1",
                        Info = "",
                    },
                    new Lesson
                    {
                        Id = 26,
                        CourseId = 5,
                        Title = "Lesson 2",
                        Info = "",
                    },
                    new Lesson
                    {
                        Id = 27,
                        CourseId = 5,
                        Title = "Lesson 3",
                        Info = "",
                    },
                    new Lesson
                    {
                        Id = 28,
                        CourseId = 5,
                        Title = "Lesson 4",
                        Info = "",
                    },
                    new Lesson
                    {
                        Id = 29,
                        CourseId = 5,
                        Title = "Lesson 5",
                        Info = "",
                    },
                    new Lesson
                    {
                        Id = 30,
                        CourseId = 5,
                        Title = "Lesson 6",
                        Info = "",
                    }
            );

            modelBuilder.Entity<Test>()
                .HasData(
                    // Math
                    new Test
                    {
                        Id = 1,
                        CourseId = 1,
                        Question = "Franklin bought several kites, each costing 16 dollars. Richard purchased several different kites, each costing 20 dollars. If the ratio of the number of kites Franklin purchased to the number of kites Richard purchased was 3 to 2, what was the average cost of each kite they purchased?",
                        Answer1 = "$16.80",
                        Answer2 = "$17.20",
                        Answer3 = "$17.60",
                        Answer4 = "$18.00",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 2,
                        CourseId = 1,
                        Question = "Circle A is inside Circle B, and the two circles share the same center O. If the circumference of B is four times the circumference of A, and the radius of Circle A is three, what is the difference between Circle B’s diameter and Circle A’s diameter?",
                        Answer1 = "6",
                        Answer2 = "9",
                        Answer3 = "12",
                        Answer4 = "18",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 3,
                        CourseId = 1,
                        Question = "There are 5 pencil-cases on the desk. Each pencil-case contains at least 10 pencils, but not more than 14 pencils. Which of the following could be the total number of pencils in all 5 cases?",
                        Answer1 = "35",
                        Answer2 = "45",
                        Answer3 = "65",
                        Answer4 = "75",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 4,
                        CourseId = 1,
                        Question = "A bird traveled 72 miles in 6 hours flying at constant speed. At this rate, how many miles did the bird travel in 5 hours?",
                        Answer1 = "12",
                        Answer2 = "30",
                        Answer3 = "60",
                        Answer4 = "14.4",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 5,
                        CourseId = 1,
                        Question = "Three kids own a total of 96 comic books. If one of the kids owns 16 of the comic books, what is the average (arithmetic mean) number of comic books owned by the other two kids?",
                        Answer1 = "40",
                        Answer2 = "42",
                        Answer3 = "44",
                        Answer4 = "46",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 6,
                        CourseId = 1,
                        Question = "If David has twice as many nickels as Tom, and Tom has 15 more nickels than John, what is the value in dollars of David’s nickels if John has 6 nickels?",
                        Answer1 = "$2.10",
                        Answer2 = "$1.40",
                        Answer3 = "$42.00",
                        Answer4 = "$21.00",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 7,
                        CourseId = 1,
                        Question = "The sum of two positive integers is 13. The difference between these numbers is 7. What is their product?",
                        Answer1 = "12",
                        Answer2 = "22",
                        Answer3 = "30",
                        Answer4 = "40",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 8,
                        CourseId = 1,
                        Question = "What is the difference between the median and the mode in the following set of data?\r\n72, 44, 58, 32, 34, 68, 94, 22, 67, 45, 58\r\n",
                        Answer1 = "0",
                        Answer2 = "2",
                        Answer3 = "4",
                        Answer4 = "6",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 9,
                        CourseId = 1,
                        Question = "You are in charge of buying T-shirts for your school’s math club. There are 27 club members, who will each receive a shirt. The T-shirts come in boxes. Each box contains 4 T-shirts and costs $23.50. What is the total cost for the T-shirts?",
                        Answer1 = "$164.50",
                        Answer2 = "$634.50",
                        Answer3 = "$141.00",
                        Answer4 = "$150.65",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 10,
                        CourseId = 1,
                        Question = "Every May, Robo Carwash offers a “Buy 4 Get 2 Free” promotion—for every 4 carwash tickets purchased at $8 per ticket, the customer receives 2 additional carwash tickets for free. What is the true cost per carwash ticket for a customer who takes advantage of the promotion?",
                        Answer1 = "$6.00",
                        Answer2 = "$5.33",
                        Answer3 = "$4.00",
                        Answer4 = "$6.67",
                        CorrectAnswer = 2, // needs to be changed
                        Points = 20
                    },
                    // Physics
                    new Test
                    {
                        Id = 11,
                        CourseId = 2,
                        Question = "Which one is NOT a vector?",
                        Answer1 = "Displacement",
                        Answer2 = "Velocity",
                        Answer3 = "Acceleration",
                        Answer4 = "Kinetic energy",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 12,
                        CourseId = 2,
                        Question = "Which of the following units would be approriate to describe force?",
                        Answer1 = "Kg*m/s^2",
                        Answer2 = "Kg/s",
                        Answer3 = "M/s^2",
                        Answer4 = "Kg*m/s",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 13,
                        CourseId = 2,
                        Question = "The fundamental force underlying all chemical reactions is",
                        Answer1 = "Nuclear",
                        Answer2 = "Centripetal",
                        Answer3 = "Electrical",
                        Answer4 = "Gravitational",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 14,
                        CourseId = 2,
                        Question = "What is the magnitude of the accleration produced by a net force of 4500 N acting on a 900 kg automobile?",
                        Answer1 = ".20 m/s^2",
                        Answer2 = "3.8 m/s^2",
                        Answer3 = "5.0 m/s^2",
                        Answer4 = "9.8 m/s^2",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 15,
                        CourseId = 2,
                        Question = "In an electrically neutral atom the number of protons in the nucleus is equal to the number of",
                        Answer1 = "Electrons that surround the nucleus",
                        Answer2 = "Neutrons in the nucleus",
                        Answer3 = "Both of these",
                        Answer4 = "Neither of these",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 16,
                        CourseId = 2,
                        Question = "A 150 lb student races up stairs with a vertical height of 3.0 m in 4.0 seconds to get to class on the second floor. how much power in watts does the student expend in doing work against gravity? (Hint: The equivalent weight of 1 kg mass = 2.2 lbs, so the students mass in kilograms 68 kg)",
                        Answer1 = "51 W",
                        Answer2 = "167 W",
                        Answer3 = "5.0 * 10^2 W",
                        Answer4 = "890 W",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 17,
                        CourseId = 2,
                        Question = "A positive ion has more",
                        Answer1 = "Electrons than neutrons",
                        Answer2 = "Electrons than protons",
                        Answer3 = "Protons than electrons",
                        Answer4 = "Protons than neutrons",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 18,
                        CourseId = 2,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 19,
                        CourseId = 2,
                        Question = "A 0.15 kg ball traveling with a speed of 50 m/s is brought to rest in a catcher's mitt with an average force of 75 N. What is the maginutde of the impulse exerted by the mitt on the ball?",
                        Answer1 = "75 Ns",
                        Answer2 = "11.3 Ns",
                        Answer3 = "3750 Ns",
                        Answer4 = "7.5 Ns",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 20,
                        CourseId = 2,
                        Question = "A 5.0-kg cat travels to the left at 10 m/s and a 10-kg dog travels to the right at 5.0 m/s. The total momentum is",
                        Answer1 = "125 kg m/s to the left",
                        Answer2 = "0",
                        Answer3 = "50 kg m/s to the right",
                        Answer4 = "100 kg m/s to the right",
                        CorrectAnswer = 2, // needs to be changed
                        Points = 20
                    },
                    // Chemistry
                    new Test
                    {
                        Id = 21,
                        CourseId = 3,
                        Question = "Which of the following are representations of the same molecule?\r\n(i) CH3CH2CH2CH2CH2CH2\r\n(ii) CH3\r\n     CH2CH2CH2CH2CH3\r\n(iii) CH2CH2CH2\r\n      CH3       CH2CH3",
                        Answer1 = "Only (i) and (ii)",
                        Answer2 = "Only (i) and (iii)",
                        Answer3 = "Only (ii) and (iii)",
                        Answer4 = "All of them",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 22,
                        CourseId = 3,
                        Question = "Which of the following explains why alkanes are called saturated hydrocarbons?",
                        Answer1 = "They contain the maximum possible number of hydrogen atoms",
                        Answer2 = "They are the most highly reactive organic compounds",
                        Answer3 = "They have dissolved to the maximum extent possible",
                        Answer4 = "They are good solvents",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 23,
                        CourseId = 3,
                        Question = "Compounds which contain a carbon-carbon triple bond are classified as which of the following?",
                        Answer1 = "Arenes",
                        Answer2 = "Alkanes",
                        Answer3 = "Alkenes",
                        Answer4 = "Alkynes",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 24,
                        CourseId = 3,
                        Question = "In organic compounds a halogen atom can replace which of the following?",
                        Answer1 = "Hydrogen",
                        Answer2 = "Oxygen",
                        Answer3 = "Nitrogen",
                        Answer4 = "Carbon",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 25,
                        CourseId = 3,
                        Question = "Which of the following is a gas at room temperature and pressure?",
                        Answer1 = "Hexane",
                        Answer2 = "Pentane",
                        Answer3 = "Butane",
                        Answer4 = "None of them",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 26,
                        CourseId = 3,
                        Question = "What is the IUPAC name of:\r\n       CH2CH2CH2CH3\r\nCH3CCH2CH3\r\n       CH2CH2CH3",
                        Answer1 = "3-methyl-3-propylheptane",
                        Answer2 = "2-ethyl-2-propylhexane",
                        Answer3 = "4-ethyl-4-methyloctane",
                        Answer4 = "None of these",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 27,
                        CourseId = 3,
                        Question = "Which of the following is true when there is a single substituent on cyclohexane?",
                        Answer1 = "The substituent will prefer to be in the axial position",
                        Answer2 = "The substituent has no particular preference for either the axial or equatorial position",
                        Answer3 = "The situation will vary, depending on the identity of the substituent",
                        Answer4 = "The substituent will prefer to be in the equatorial position",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 28,
                        CourseId = 3,
                        Question = "How many moles of oxygen are consumed by the complete combustion of one mole of propane, C3H8?",
                        Answer1 = "7",
                        Answer2 = "1",
                        Answer3 = "5",
                        Answer4 = "3",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 29,
                        CourseId = 3,
                        Question = "Which of the following has the highest boiling point?",
                        Answer1 = "Hexane",
                        Answer2 = "Octane",
                        Answer3 = "Nonane",
                        Answer4 = "Heptane",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 30,
                        CourseId = 3,
                        Question = "In which of the following classes of organic compounds is an oxygen atom bonded to a hydrogen atom?",
                        Answer1 = "Alcohols",
                        Answer2 = "Aldehydes",
                        Answer3 = "Amines",
                        Answer4 = "All of these",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    // Biology
                    new Test
                    {
                        Id = 31,
                        CourseId = 4,
                        Question = "A snake that eats a frog that has eaten an insect that fed on a plant is a",
                        Answer1 = "First level producer",
                        Answer2 = "First level consumer",
                        Answer3 = "Secong level producer",
                        Answer4 = "Third level consumer",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 32,
                        CourseId = 4,
                        Question = "The movements of energy and nutrients through living systems are different because",
                        Answer1 = "Energy flows in one direction and nutrients recycle",
                        Answer2 = "Energy is limited in the biosphere and nutrients are always available",
                        Answer3 = "Nutrients flow in one direction and energy recycles",
                        Answer4 = "Energy forms chemical compounds and nutrients are lost as heat",
                        CorrectAnswer = 0, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 33,
                        CourseId = 4,
                        Question = "Which is a biotic factor that affects the size of a population in a specific ecosystem?",
                        Answer1 = "Average temperature of the ecosystem",
                        Answer2 = "Type of soil in the ecosystem",
                        Answer3 = "Number and kinds of predators in the ecosystem",
                        Answer4 = "Concentration of oxygen in the ecosystem",
                        CorrectAnswer = 0, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 34,
                        CourseId = 4,
                        Question = "The symbiotic relationship between a flower and the insect that feeds on its nectar is an example of",
                        Answer1 = "Mutualism because the flower provides the insect with food, and the insect pollinates the flower",
                        Answer2 = "Parasitism because the insect lives off the nectar from the flower",
                        Answer3 = "Commensalism because the insect doesn’t harm the flower, and the flower doesn’t benefit from the relationship",
                        Answer4 = "Predation because the insect feeds on the flower",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 35,
                        CourseId = 4,
                        Question = "What is one difference between primary and secondary succession?",
                        Answer1 = "Primary succession is slow, and secondary succession is rapid",
                        Answer2 = "Secondary succession begins on soil, and primary succession begins on newly exposed surfaces",
                        Answer3 = "Primary succession modifies the environment, and secondary succession does not",
                        Answer4 = "Secondary succession begins with lichens, and primary succession begins with trees",
                        CorrectAnswer = 2, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 36,
                        CourseId = 4,
                        Question = "A forest fire destroys the majority of the trees in a state park. Which effect will this most likely have on secondary consumers in that ecosystem?",
                        Answer1 = "The amount of available energy will increase because there will be fewer predators in the forest",
                        Answer2 = "The amount of available energy will increase because there will be less competition from producers.",
                        Answer3 = "The amount to available energy will decrease because fewer primary consumers will survive the lack of vegetation",
                        Answer4 = "The amount of energy will remain constant because secondary consumers are not reliant on primary consumers",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 37,
                        CourseId = 4,
                        Question = "A new species of snake was introduced to a tropical region. Scientists noticed a steady decline in the presence of field mice and an increase in the number of snakes. Which of these is the MOST LIKELY explanation for why the population size of each animal changed?",
                        Answer1 = "The snakes introduced to the region dominated the habitat, forcing the mice to find another place to live",
                        Answer2 = "The mice became prey to the intoduced snakes, allowing the snake population to increase but decreasing the mice population.",
                        Answer3 = "The snakes introduced to the region competed with the mice for food, allowing the snake population to increase but decreasing the mice population.",
                        Answer4 = "The people in the surrounding area set traps that killed the mice, allowing the snakes to live without any predators and therefore to increase the number.",
                        CorrectAnswer = 2, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 38,
                        CourseId = 4,
                        Question = "If a population grows larger than the carrying capacity of the environment, the",
                        Answer1 = "Death rate may rise",
                        Answer2 = "Birth rate may rise",
                        Answer3 = "Population will grow faster",
                        Answer4 = "Carrying capacity will change",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 39,
                        CourseId = 4,
                        Question = "All of the following are threats to biodiversity EXCEPT",
                        Answer1 = "Biological magnification of toxic compounds",
                        Answer2 = "Habitat fragmentation",
                        Answer3 = "Invasive species",
                        Answer4 = "Species preservation",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 40,
                        CourseId = 4,
                        Question = "One species of Galapagos finches, the cactus finch, eats insects off cactus plants. A disease kills off most of the cacti in the Galapagos Islands. Which of these most likely would happen to the carrying capacity of the island?",
                        Answer1 = "It would increase a small amount since the insect population would decrease",
                        Answer2 = "It would remain about the same since the finches would change to a different habitat",
                        Answer3 = "It would increase exponentially since the insects would have limited places to hide",
                        Answer4 = "It would decrease considerably since the finches are specifically adapted to their niche",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    // Informatics
                    new Test
                    {
                        Id = 41,
                        CourseId = 5,
                        Question = "When you see no icons on the desktop, how can you open programs such as Microsoft Word?",
                        Answer1 = "Right-click to reveal all icons",
                        Answer2 = "Restart the computer",
                        Answer3 = "It is not possible to open the program if no icons are on the desktop",
                        Answer4 = "Click the start button and select the program icon from the menu",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 42,
                        CourseId = 5,
                        Question = "What is the primary function of an operating system?",
                        Answer1 = "Creating documents",
                        Answer2 = "Managing hardware and software resources",
                        Answer3 = "Browsing the internet",
                        Answer4 = "Playing games",
                        CorrectAnswer = 2, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 43,
                        CourseId = 5,
                        Question = "When writing a program, what is true about program documentation?\r\nI. Program documentation is useful while writing the program.\r\nII. Program documentation is useful after the program is written.\r\nIII. Program documentation is not useful when run speed is a factor.",
                        Answer1 = "I only",
                        Answer2 = "I and II",
                        Answer3 = "II only",
                        Answer4 = "I, II, and III",
                        CorrectAnswer = 2, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 44,
                        CourseId = 5,
                        Question = "What is true about high-level programming languages?\r\nI. High-level languages are easier to debug and easier to code than machine code.\r\nII. High-level languages contain the most abstractions.\r\nIII. High-level languages are translated to machine code when executed on a computer.",
                        Answer1 = "I only",
                        Answer2 = "III only",
                        Answer3 = "II and III",
                        Answer4 = "I, II, and III",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 45,
                        CourseId = 5,
                        Question = "Hardware is built using multiple levels of abstractions. A computer is an abstraction. By making a computer an abstraction, it hides the complexity of the computer components, allowing the programmer to focus on programming\r\n\r\nWhich of the following lists hardware in order from high- to low-level hardware abstraction?",
                        Answer1 = "Computer, transistor, graphics card",
                        Answer2 = "Logic gate, transistor, graphics card",
                        Answer3 = "Computer, video card, transistor",
                        Answer4 = "Logic gate, video card, transistor",
                        CorrectAnswer = 3, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 46,
                        CourseId = 5,
                        Question = "Which of the following examples LEAST likely indicates a phishing attack?",
                        Answer1 = "An email indicates that a password is expiring and asks you to click a link to renew your password.",
                        Answer2 = "An email from a familiar company, which has the exact look of previous emails from this company, reports that the current credit card information on file has expired, and has a link for you to reenter credit card information.",
                        Answer3 = "An email from the IRS contains the correct IRS logo and asks you to submit your social security number so the IRS can mail an additional tax refund. Additionally, the email contains a warning that if this information is not filled out within 30 days the refund will be lost.",
                        Answer4 = "An email from your credit card company with the correct bank logo indicates that there has been unusual activity on your credit card and to call the number on your card to confirm the purchase.",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 47,
                        CourseId = 5,
                        Question = "To get their AP scores hours earlier, if not days earlier, than the scheduled release time, students will hide their IP address so they appear to be in a different time zone. What device can students use to hide their IP address?",
                        Answer1 = "Proxy server",
                        Answer2 = "Domain name server",
                        Answer3 = "Distributed denial-of-service (DDoS) attacks",
                        Answer4 = "Phishing attack",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 48,
                        CourseId = 5,
                        Question = "A computer can use 6 bits to store non-negative numbers. Which of the following will NOT give an overflow error?\r\n\r\nI. 64\r\nII. 63\r\nIII. 54\r\nIV. 89",
                        Answer1 = "All of the above",
                        Answer2 = "II, III, and IV",
                        Answer3 = "I and III",
                        Answer4 = "II and III",
                        CorrectAnswer = 4, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 49,
                        CourseId = 5,
                        Question = "Two computers calculate the same equation:\r\na ← 1/3\r\n\r\nA second computer calculates\r\nb ← 1/3\r\n\r\nIf (a ≠ b), what error has occurred?",
                        Answer1 = "Roundoff error",
                        Answer2 = "Overflow error",
                        Answer3 = "DDoS attack",
                        Answer4 = "Phishing",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    },
                    new Test
                    {
                        Id = 50,
                        CourseId = 5,
                        Question = "What error is displayed by the algorithm below?\r\na ← 8\r\nb ← 5\r\nc ← b – 3\r\nd ← c – 2\r\nDISPLAY(a)\r\nDISPLAY(5/d)",
                        Answer1 = "Divide by zero error",
                        Answer2 = "Short circuit",
                        Answer3 = "Overflow error",
                        Answer4 = "No error",
                        CorrectAnswer = 1, // needs to be changed
                        Points = 20
                    }
            );

            modelBuilder.Entity<Doc>()
                .HasData(
                    // Math
                    new Doc
                    {
                        Id = 1,
                        CourseId = 1,
                        LessonId = 1,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 2,
                        CourseId = 1,
                        LessonId = 2,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 3,
                        CourseId = 1,
                        LessonId = 3,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 4,
                        CourseId = 1,
                        LessonId = 4,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 5,
                        CourseId = 1,
                        LessonId = 5,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 6,
                        CourseId = 1,
                        LessonId = 6,
                        Title = "",
                        Url = ""
                    },
                    // Physics
                    new Doc
                    {
                        Id = 7,
                        CourseId = 2,
                        LessonId = 7,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 8,
                        CourseId = 2,
                        LessonId = 8,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 9,
                        CourseId = 2,
                        LessonId = 9,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 10,
                        CourseId = 2,
                        LessonId = 10,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 11,
                        CourseId = 2,
                        LessonId = 11,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 12,
                        CourseId = 2,
                        LessonId = 12,
                        Title = "",
                        Url = ""
                    },
                    // Chemistry
                    new Doc
                    {
                        Id = 13,
                        CourseId = 3,
                        LessonId = 13,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 14,
                        CourseId = 3,
                        LessonId = 14,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 15,
                        CourseId = 3,
                        LessonId = 15,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 16,
                        CourseId = 3,
                        LessonId = 16,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 17,
                        CourseId = 3,
                        LessonId = 17,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 18,
                        CourseId = 3,
                        LessonId = 18,
                        Title = "",
                        Url = ""
                    },
                    // Biology
                    new Doc
                    {
                        Id = 19,
                        CourseId = 4,
                        LessonId = 19,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 20,
                        CourseId = 4,
                        LessonId = 20,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 21,
                        CourseId = 4,
                        LessonId = 21,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 22,
                        CourseId = 4,
                        LessonId = 22,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 23,
                        CourseId = 4,
                        LessonId = 23,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 24,
                        CourseId = 4,
                        LessonId = 24,
                        Title = "",
                        Url = ""
                    },
                    // Informatics
                    new Doc
                    {
                        Id = 25,
                        CourseId = 5,
                        LessonId = 25,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 26,
                        CourseId = 5,
                        LessonId = 26,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 27,
                        CourseId = 5,
                        LessonId = 27,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 28,
                        CourseId = 5,
                        LessonId = 28,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 29,
                        CourseId = 5,
                        LessonId = 29,
                        Title = "",
                        Url = ""
                    },
                    new Doc
                    {
                        Id = 30,
                        CourseId = 5,
                        LessonId = 30,
                        Title = "",
                        Url = ""
                    }
            );

            modelBuilder.Entity<Video>()
                .HasData(
                    // Math
                    new Video
                    {
                        Id = 1,
                        CourseId = 1,
                        LessonId = 1,
                        Title = "What is a variable",
                        Url = "What is a variable.mp4"
                    },
                    new Video
                    {
                        Id = 2,
                        CourseId = 1,
                        LessonId = 2,
                        Title = "How to evaluate expressions with two variables",
                        Url = "How to evaluate expressions with two variables.mp4"
                    },
                    new Video
                    {
                        Id = 3,
                        CourseId = 1,
                        LessonId = 3,
                        Title = "How to write basic expressions with variables",
                        Url = "How to write basic expressions with variables.mp4"
                    },
                    new Video
                    {
                        Id = 4,
                        CourseId = 1,
                        LessonId = 4,
                        Title = "Combining like terms introduction",
                        Url = "Combining like terms introduction.mp4"
                    },
                    new Video
                    {
                        Id = 5,
                        CourseId = 1,
                        LessonId = 5,
                        Title = "How to use the distributive property with variables",
                        Url = "How to use the distributive property with variables.mp4"
                    },
                    new Video
                    {
                        Id = 6,
                        CourseId = 1,
                        LessonId = 6,
                        Title = "How to find equivalent expressions by combining like terms",
                        Url = "How to find equivalent expressions by combining like terms.mp4"
                    },
                    // Physics
                    new Video
                    {
                        Id = 7,
                        CourseId = 2,
                        LessonId = 7,
                        Title = "Introduction to physics",
                        Url = "Introduction to physics.mp4"
                    },
                    new Video
                    {
                        Id = 8,
                        CourseId = 2,
                        LessonId = 8,
                        Title = "Distance and displacement introduction",
                        Url = "Distance and displacement introduction.mp4"
                    },
                    new Video
                    {
                        Id = 9,
                        CourseId = 2,
                        LessonId = 9,
                        Title = "Average velocity and speed worked example",
                        Url = "Average velocity and speed worked example.mp4"
                    },
                    new Video
                    {
                        Id = 10,
                        CourseId = 2,
                        LessonId = 10,
                        Title = "Instantaneous speed and velocity",
                        Url = "Instantaneous speed and velocity.mp4"
                    },
                    new Video
                    {
                        Id = 11,
                        CourseId = 2,
                        LessonId = 11,
                        Title = "Acceleration",
                        Url = "Acceleration.mp4"
                    },
                    new Video
                    {
                        Id = 12,
                        CourseId = 2,
                        LessonId = 12,
                        Title = "Choosing kinematic equations",
                        Url = "Choosing kinematic equations.mp4"
                    },
                    // Chemistry
                    new Video
                    {
                        Id = 13,
                        CourseId = 3,
                        LessonId = 13,
                        Title = "Average atomic mass",
                        Url = "Average atomic mass.mp4"
                    },
                    new Video
                    {
                        Id = 14,
                        CourseId = 3,
                        LessonId = 14,
                        Title = "Isotopes",
                        Url = "Isotopes.mp4"
                    },
                    new Video
                    {
                        Id = 15,
                        CourseId = 3,
                        LessonId = 15,
                        Title = "Empirical, molecular, and structural formulas",
                        Url = "Empirical, molecular, and structural formulas.mp4"
                    },
                    new Video
                    {
                        Id = 16,
                        CourseId = 3,
                        LessonId = 16,
                        Title = "Calculating the mass of a substance in a mixture",
                        Url = "Calculating the mass of a substance in a mixture.mp4"
                    },
                    new Video
                    {
                        Id = 17,
                        CourseId = 3,
                        LessonId = 17,
                        Title = "Shells, subshells, and orbitals",
                        Url = "Shells, subshells, and orbitals.mp4"
                    },
                    new Video
                    {
                        Id = 18,
                        CourseId = 3,
                        LessonId = 18,
                        Title = "Periodic trends and Coulomb's law",
                        Url = "Periodic trends and Coulomb's law.mp4"
                    },
                    // Biology
                    new Video
                    {
                        Id = 19,
                        CourseId = 4,
                        LessonId = 19,
                        Title = "Biology overview",
                        Url = "Biology overview.mp4"
                    },
                    new Video
                    {
                        Id = 20,
                        CourseId = 4,
                        LessonId = 20,
                        Title = "Elements and atoms",
                        Url = "Elements and atoms.mp4"
                    },
                    new Video
                    {
                        Id = 21,
                        CourseId = 4,
                        LessonId = 21,
                        Title = "Hydrogen bonding in water",
                        Url = "Hydrogen bonding in water.mp4"
                    },
                    new Video
                    {
                        Id = 22,
                        CourseId = 4,
                        LessonId = 22,
                        Title = "Introduction to pH",
                        Url = "Introduction to pH.mp4"
                    },
                    new Video
                    {
                        Id = 23,
                        CourseId = 4,
                        LessonId = 23,
                        Title = "Scale of cells",
                        Url = "Scale of cells.mp4"
                    },
                    new Video
                    {
                        Id = 24,
                        CourseId = 4,
                        LessonId = 24,
                        Title = "Introduction to the cell",
                        Url = "Introduction to the cell.mp4"
                    },
                    // Informatics
                    new Video
                    {
                        Id = 25,
                        CourseId = 5,
                        LessonId = 25,
                        Title = "",
                        Url = ""
                    },
                    new Video
                    {
                        Id = 26,
                        CourseId = 5,
                        LessonId = 26,
                        Title = "",
                        Url = ""
                    },
                    new Video
                    {
                        Id = 27,
                        CourseId = 5,
                        LessonId = 27,
                        Title = "",
                        Url = ""
                    },
                    new Video
                    {
                        Id = 28,
                        CourseId = 5,
                        LessonId = 28,
                        Title = "",
                        Url = ""
                    },
                    new Video
                    {
                        Id = 29,
                        CourseId = 5,
                        LessonId = 29,
                        Title = "",
                        Url = ""
                    },
                    new Video
                    {
                        Id = 30,
                        CourseId = 5,
                        LessonId = 30,
                        Title = "",
                        Url = ""
                    }
            );

            modelBuilder.Entity<Homework>()
                .HasData(
                    // Math
                    new Homework
                    {
                        Id = 1,
                        CourseId = 1,
                        LessonId = 1,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 2,
                        CourseId = 1,
                        LessonId = 2,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 3,
                        CourseId = 1,
                        LessonId = 3,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 4,
                        CourseId = 1,
                        LessonId = 4,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 5,
                        CourseId = 1,
                        LessonId = 5,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 6,
                        CourseId = 1,
                        LessonId = 6,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    // Physics
                    new Homework
                    {
                        Id = 7,
                        CourseId = 2,
                        LessonId = 7,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 8,
                        CourseId = 2,
                        LessonId = 8,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 9,
                        CourseId = 2,
                        LessonId = 9,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 10,
                        CourseId = 2,
                        LessonId = 10,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 11,
                        CourseId = 2,
                        LessonId = 11,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 12,
                        CourseId = 2,
                        LessonId = 12,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    // Chemistry
                    new Homework
                    {
                        Id = 13,
                        CourseId = 3,
                        LessonId = 13,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 14,
                        CourseId = 3,
                        LessonId = 14,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 15,
                        CourseId = 3,
                        LessonId = 15,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 16,
                        CourseId = 3,
                        LessonId = 16,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 17,
                        CourseId = 3,
                        LessonId = 17,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 18,
                        CourseId = 3,
                        LessonId = 18,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    // Biology
                    new Homework
                    {
                        Id = 19,
                        CourseId = 4,
                        LessonId = 19,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 20,
                        CourseId = 4,
                        LessonId = 20,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 21,
                        CourseId = 4,
                        LessonId = 21,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 22,
                        CourseId = 4,
                        LessonId = 22,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 23,
                        CourseId = 4,
                        LessonId = 23,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 24,
                        CourseId = 4,
                        LessonId = 24,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    // Informatics
                    new Homework
                    {
                        Id = 25,
                        CourseId = 5,
                        LessonId = 25,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 26,
                        CourseId = 5,
                        LessonId = 26,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 27,
                        CourseId = 5,
                        LessonId = 27,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 28,
                        CourseId = 5,
                        LessonId = 28,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 29,
                        CourseId = 5,
                        LessonId = 29,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    },
                    new Homework
                    {
                        Id = 30,
                        CourseId = 5,
                        LessonId = 30,
                        Title = "Homework 1",
                        Description = "",
                        Deadline = new DateOnly(2024, 5, 5)
                    }
            );

            modelBuilder.Entity<Material>()
                .HasData(
                    // Math
                    new Material
                    {
                        Id = 1,
                        CourseId = 1,
                        LessonId = 1,
                        HomeworkId = 1,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 2,
                        CourseId = 1,
                        LessonId = 2,
                        HomeworkId = 2,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 3,
                        CourseId = 1,
                        LessonId = 3,
                        HomeworkId = 3,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 4,
                        CourseId = 1,
                        LessonId = 4,
                        HomeworkId = 4,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 5,
                        CourseId = 1,
                        LessonId = 5,
                        HomeworkId = 5,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 6,
                        CourseId = 1,
                        LessonId = 6,
                        HomeworkId = 6,
                        Title = "",
                        Url = ""
                    },
                    // Physics
                    new Material
                    {
                        Id = 7,
                        CourseId = 2,
                        LessonId = 7,
                        HomeworkId = 7,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 8,
                        CourseId = 2,
                        LessonId = 8,
                        HomeworkId = 8,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 9,
                        CourseId = 2,
                        LessonId = 9,
                        HomeworkId = 9,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 10,
                        CourseId = 2,
                        LessonId = 10,
                        HomeworkId = 10,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 11,
                        CourseId = 2,
                        LessonId = 11,
                        HomeworkId = 11,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 12,
                        CourseId = 2,
                        LessonId = 12,
                        HomeworkId = 12,
                        Title = "",
                        Url = ""
                    },
                    // Chemistry
                    new Material
                    {
                        Id = 13,
                        CourseId = 3,
                        LessonId = 13,
                        HomeworkId = 13,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 14,
                        CourseId = 3,
                        LessonId = 14,
                        HomeworkId = 14,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 15,
                        CourseId = 3,
                        LessonId = 15,
                        HomeworkId = 15,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 16,
                        CourseId = 3,
                        LessonId = 16,
                        HomeworkId = 16,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 17,
                        CourseId = 3,
                        LessonId = 17,
                        HomeworkId = 17,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 18,
                        CourseId = 3,
                        LessonId = 18,
                        HomeworkId = 18,
                        Title = "",
                        Url = ""
                    },
                    // Biology
                    new Material
                    {
                        Id = 19,
                        CourseId = 4,
                        LessonId = 19,
                        HomeworkId = 19,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 20,
                        CourseId = 4,
                        LessonId = 20,
                        HomeworkId = 20,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 21,
                        CourseId = 4,
                        LessonId = 21,
                        HomeworkId = 21,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 22,
                        CourseId = 4,
                        LessonId = 22,
                        HomeworkId = 22,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 23,
                        CourseId = 4,
                        LessonId = 23,
                        HomeworkId = 23,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 24,
                        CourseId = 4,
                        LessonId = 24,
                        HomeworkId = 24,
                        Title = "",
                        Url = ""
                    },
                    // Informatics
                    new Material
                    {
                        Id = 25,
                        CourseId = 5,
                        LessonId = 25,
                        HomeworkId = 25,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 26,
                        CourseId = 5,
                        LessonId = 26,
                        HomeworkId = 26,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 27,
                        CourseId = 5,
                        LessonId = 27,
                        HomeworkId = 27,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 28,
                        CourseId = 5,
                        LessonId = 28,
                        HomeworkId = 28,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 29,
                        CourseId = 5,
                        LessonId = 29,
                        HomeworkId = 29,
                        Title = "",
                        Url = ""
                    },
                    new Material
                    {
                        Id = 30,
                        CourseId = 5,
                        LessonId = 30,
                        HomeworkId = 30,
                        Title = "",
                        Url = ""
                    }
                );

        }
    }
}
