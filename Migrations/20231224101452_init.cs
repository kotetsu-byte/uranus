using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Uranus.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "text", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: true),
                    Answer1 = table.Column<string>(type: "text", nullable: true),
                    Answer2 = table.Column<string>(type: "text", nullable: true),
                    Answer3 = table.Column<string>(type: "text", nullable: true),
                    Answer4 = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<int>(type: "integer", nullable: true),
                    Points = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Docs_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    IsDone = table.Column<bool>(type: "boolean", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homeworks_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Homeworks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videos_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    HomeworkId = table.Column<int>(type: "integer", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Mathematics is an area of knowledge that includes the topics of numbers, formulas and related structures, shapes and the spaces in which they are contained, and quantities and their changes.", "Math", 3000000.0 },
                    { 2, "Physics is the natural science of matter, involving the study of matter, its fundamental constituents, its motion and behavior through space and time, and the related entities of energy and force.", "Physics", 3000000.0 },
                    { 3, "Chemistry is the scientific study of the properties and behavior of matter.", "Chemistry", 3000000.0 },
                    { 4, "Biology is the scientific study of life.", "Biology", 3000000.0 },
                    { 5, "Informatics is the study of computational systems.", "Informatics", 3000000.0 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "Info", "Title" },
                values: new object[,]
                {
                    { 1, 1, "In mathematics, a variable (from Latin variabilis, \"changeable\") is a symbol that represents a mathematical object. A variable may represent a number, a vector, a matrix, a function, the argument of a function, a set, or an element of a set.\r\n\r\nAlgebraic computations with variables as if they were explicit numbers solve a range of problems in a single computation. For example, the quadratic formula solves any quadratic equation by substituting the numeric values of the coefficients of that equation for the variables that represent them in the quadratic formula. In mathematical logic, a variable is either a symbol representing an unspecified term of the theory (a meta-variable), or a basic object of the theory that is manipulated without referring to its possible intuitive interpretation.", "Lesson 1" },
                    { 2, 1, "There are many methods for solving a system of linear equation, one of them is elimination method.\r\n\r\nAs the name suggest in elimination method, we eliminate one of the variables by subtracting one equation from another (or first multiplying one of the equation with some number and then subtracting from other equation).", "Lesson 2" },
                    { 3, 1, "Terms in an algebraic expression are separated by addition operators and factors are separated by multiplication operators. The numerical factor of a term is called the coefficient. For example, the algebraic expression x2y2+6xy−3\r\n can be thought of as  x2y2+6xy+(−3)\r\n and has three terms. The first term, x2y2\r\n, represents the quantity  1x2y2=1⋅x⋅x⋅y⋅y\r\n where 1 is the coefficient and x and y are the variables. All of the variable factors with their exponents form the variable part of a term.", "Lesson 3" },
                    { 4, 1, "Combining like terms means to simplify an algebraic expression by counting the variables that are the same. Simply look at each letter in turn and add the numbers in front of them to see how many there are in total.", "Lesson 4" },
                    { 5, 1, "Distributive property is the algebraic property used to multiply a number with the sum or difference of two or more numbers within a parenthesis. We can say that the distributive property helps in simplifying the problems by breaking the expressions into addition or subtraction of products or vice versa.", "Lesson 5" },
                    { 6, 1, "In order to understand what “combining like terms” means, let’s get some basic definitions out of the way. First, we have to understand the concept of a term. In algebra, a term can be a number, variable, or product (the multiplication) of a number and variable. Recall, a variable can represent any possible number. Typically in algebra, we use symbols like x or y to represent variables.", "Lesson 6" },
                    { 7, 2, "The physical universe is enormously complex in its detail. Every day, each of us observes a great variety of objects and phenomena. Over the centuries, the curiosity of the human race has led us collectively to explore and catalog a tremendous wealth of information. From the flight of birds to the colors of flowers, from lightning to gravity, from quarks to clusters of galaxies, from the flow of time to the mystery of the creation of the universe, we have asked questions and assembled huge arrays of facts. In the face of all these details, we have discovered that a surprisingly small and unified set of physical laws can explain what we observe. As humans, we make generalizations and seek order. We have found that nature is remarkably cooperative—it exhibits the underlying order and simplicity we so value.", "Lesson 1" },
                    { 8, 2, "Distance is the measurement of paths taken by an object. In simple words, distance is something an object covers in a given time ‘t. ‘ However, displacement is the shortest path taken by an object during its motion. Distance and displacement are two physical quantities that we use in our everyday life.", "Lesson 2" },
                    { 9, 2, "Average speed is a rate that is a quantity divided by the time taken to get that quantity. SI unit of speed is meters per second. Average speed is calculated by the formula S = d/t, where S equals the average speed, d equals total distance and t equals total time. Average Velocity. Average velocity of an object can be defined as the displacement with regards to the original position divided by the time.", "Lesson 3" },
                    { 10, 2, "The instantaneous speed is the speed of an object at a particular moment in time. And if you include the direction with that speed, you get the instantaneous velocity. In other words, eight meters per second to the right was the instantaneously velocity of this person at that particular moment in time.", "Lesson 4" },
                    { 11, 2, "In mechanics, acceleration is the rate of change of the velocity of an object with respect to time. Acceleration is one of several components of kinematics, the study of motion. Accelerations are vector quantities (in that they have magnitude and direction). The orientation of an object's acceleration is given by the orientation of the net force acting on that object.", "Lesson 5" },
                    { 12, 2, "Kinematics equations are the constraint equations of a mechanical system such as a robot manipulator that define how input movement at one or more joints specifies the configuration of the device, in order to achieve a task position or end-effector location. Kinematics equations are used to analyze and design articulated systems ranging from four-bar linkages to serial and parallel robots.", "Lesson 6" },
                    { 13, 3, "The average atomic mass (sometimes called atomic weight) of an element is the weighted average mass of the atoms in a naturally occurring sample of the element. Average masses are generally expressed in unified atomic mass units (u), where 1 u is equal to exactly one-twelfth the mass of a neutral atom of carbon-12. Created by Sal Khan. So the atomic mass unit is 1/12th the mass of carbon-12.", "Lesson 1" },
                    { 14, 3, "Isotopes are two or more types of chemical species or elements that are having same atomic number and the same position in the periodic table of elements. isotopes have different mass numbers or nucleon numbers due to the difference in the number of neutrons in their nuclei. However, all isotopes of a particular element have almost the same chemical properties and different atomic masses, and physical properties.", "Lesson 2" },
                    { 15, 3, "There are three main types of chemical formulas: empirical, molecular and structural. Empirical formulas show the simplest whole-number ratio of atoms in a compound, molecular formulas show the number of each type of atom in a molecule, and structural formulas show how the atoms in a molecule are bonded to each other.", "Lesson 3" },
                    { 16, 3, "Elemental analysis can be used to determine the amounts of substances in a mixture. For example, if elemental analysis tells us that a potassium supplement contains 22% K by mass, and we know that the K is present as KCl, we can calculate the grams of KCl in the supplement.", "Lesson 4" },
                    { 17, 3, "The main difference between shell subshell and orbital is that shells are composed of electrons that share the same principal quantum number and subshells are composed of electrons that share the same angular momentum quantum number whereas orbitals are composed of electrons that are in the same energy level but have different spins.", "Lesson 5" },
                    { 18, 3, "Periodic trends are specific patterns that are present in the periodic table that illustrate different aspects of a certain element. They were discovered by the Russian chemist Dmitri Mendeleev in the year 1863. Major periodic trends include atomic radius, ionization energy, electron affinity, electronegativity, valency and metallic character.", "Lesson 6" },
                    { 19, 4, "Biology is the branch of science that primarily deals with the structure, function, growth, evolution, and distribution of organisms. As a science, it is a methodological study of life and living things. It determines verifiable facts or formulates theories based on experimental findings on living things by applying the scientific method. An expert in this field is called a biologist.", "Lesson 1" },
                    { 20, 4, "Difference between Elements and Atoms is that Elements are made from atoms and atoms are the smallest part of elements. Elements are the simplest form of any substance and. Atoms are the simplest unit of matter. An element cannot be further broken down by chemical reactions into simpler substances. Elements are made of atoms that have the same atomic number i.e. the nucleus contains the same number of protons.", "Lesson 2" },
                    { 21, 4, "The hydrogen bonding in water is a vigorous bond between the nearest water molecule containing one Hydrogen atom between two oxygen atoms. Hydrogen bonding is major of two types of intramolecular and intermolecular hydrogen bonding, on the basis of the atoms involved in it. Hydrogen bonding is maximum in solid-state compounds.", "Lesson 3" },
                    { 22, 4, "The term “pH” is an abbreviation for the “potential of hydrogen.” pH is a unit of measurement that represents the concentration of hydrogen ions in a solution. This unit was introduced by biochemist Søren Peter Lauritz Sørensen in 1909. It was an easy way to represent the concentration of hydrogen ions in a solution during titrations. When an acid or base is added to water, that compound dissociates into ions.", "Lesson 4" },
                    { 23, 4, "The smallest objects that the unaided human eye can see are about 0.1 mm long. That means that under the right conditions, you might be able to see an amoeba proteus, a human egg, and a paramecium without using magnification. A magnifying glass can help you to see them more clearly, but they will still look tiny.", "Lesson 5" },
                    { 24, 4, "The human body is made up of “just” 200–400 cell types, but we (i.e. you and I) have copious amount of each cell types. In fact, there is a mind-bogglingly 10¹⁴ cells (that’s 100 trillion of cells) in a human body, organized into tissues and organs that give rise to life. Cells come in thousands of shapes and sizes, but they are so small that 10,000 of our cells could all fit on the head of a pin. To sustain life, the cells in our body go through 5 x 10¹⁷ biochemical reactions per second (that’s 500 quadrillion every second!). That is why biochemistry plays such a crucial role in understanding cells (and life) and has important medical applications.", "Lesson 6" },
                    { 25, 5, "", "Lesson 1" },
                    { 26, 5, "", "Lesson 2" },
                    { 27, 5, "", "Lesson 3" },
                    { 28, 5, "", "Lesson 4" },
                    { 29, 5, "", "Lesson 5" },
                    { 30, 5, "", "Lesson 6" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Answer1", "Answer2", "Answer3", "Answer4", "CorrectAnswer", "CourseId", "Points", "Question" },
                values: new object[,]
                {
                    { 1, "$16.80", "$17.20", "$17.60", "$18.00", 3, 1, 20, "Franklin bought several kites, each costing 16 dollars. Richard purchased several different kites, each costing 20 dollars. If the ratio of the number of kites Franklin purchased to the number of kites Richard purchased was 3 to 2, what was the average cost of each kite they purchased?" },
                    { 2, "6", "9", "12", "18", 4, 1, 20, "Circle A is inside Circle B, and the two circles share the same center O. If the circumference of B is four times the circumference of A, and the radius of Circle A is three, what is the difference between Circle B’s diameter and Circle A’s diameter?" },
                    { 3, "35", "45", "65", "75", 3, 1, 20, "There are 5 pencil-cases on the desk. Each pencil-case contains at least 10 pencils, but not more than 14 pencils. Which of the following could be the total number of pencils in all 5 cases?" },
                    { 4, "12", "30", "60", "14.4", 3, 1, 20, "A bird traveled 72 miles in 6 hours flying at constant speed. At this rate, how many miles did the bird travel in 5 hours?" },
                    { 5, "40", "42", "44", "46", 1, 1, 20, "Three kids own a total of 96 comic books. If one of the kids owns 16 of the comic books, what is the average (arithmetic mean) number of comic books owned by the other two kids?" },
                    { 6, "$2.10", "$1.40", "$42.00", "$21.00", 1, 1, 20, "If David has twice as many nickels as Tom, and Tom has 15 more nickels than John, what is the value in dollars of David’s nickels if John has 6 nickels?" },
                    { 7, "12", "22", "30", "40", 3, 1, 20, "The sum of two positive integers is 13. The difference between these numbers is 7. What is their product?" },
                    { 8, "0", "2", "4", "6", 1, 1, 20, "What is the difference between the median and the mode in the following set of data?\r\n72, 44, 58, 32, 34, 68, 94, 22, 67, 45, 58\r\n" },
                    { 9, "$164.50", "$634.50", "$141.00", "$150.65", 1, 1, 20, "You are in charge of buying T-shirts for your school’s math club. There are 27 club members, who will each receive a shirt. The T-shirts come in boxes. Each box contains 4 T-shirts and costs $23.50. What is the total cost for the T-shirts?" },
                    { 10, "$6.00", "$5.33", "$4.00", "$6.67", 2, 1, 20, "Every May, Robo Carwash offers a “Buy 4 Get 2 Free” promotion—for every 4 carwash tickets purchased at $8 per ticket, the customer receives 2 additional carwash tickets for free. What is the true cost per carwash ticket for a customer who takes advantage of the promotion?" },
                    { 11, "Displacement", "Velocity", "Acceleration", "Kinetic energy", 4, 2, 20, "Which one is NOT a vector?" },
                    { 12, "Kg*m/s^2", "Kg/s", "M/s^2", "Kg*m/s", 1, 2, 20, "Which of the following units would be approriate to describe force?" },
                    { 13, "Nuclear", "Centripetal", "Electrical", "Gravitational", 3, 2, 20, "The fundamental force underlying all chemical reactions is" },
                    { 14, ".20 m/s^2", "3.8 m/s^2", "5.0 m/s^2", "9.8 m/s^2", 3, 2, 20, "What is the magnitude of the accleration produced by a net force of 4500 N acting on a 900 kg automobile?" },
                    { 15, "Electrons that surround the nucleus", "Neutrons in the nucleus", "Both of these", "Neither of these", 1, 2, 20, "In an electrically neutral atom the number of protons in the nucleus is equal to the number of" },
                    { 16, "51 W", "167 W", "5.0 * 10^2 W", "890 W", 3, 2, 20, "A 150 lb student races up stairs with a vertical height of 3.0 m in 4.0 seconds to get to class on the second floor. how much power in watts does the student expend in doing work against gravity? (Hint: The equivalent weight of 1 kg mass = 2.2 lbs, so the students mass in kilograms 68 kg)" },
                    { 17, "Electrons than neutrons", "Electrons than protons", "Protons than electrons", "Protons than neutrons", 3, 2, 20, "A positive ion has more" },
                    { 18, "", "", "", "", 0, 2, 20, "" },
                    { 19, "75 Ns", "11.3 Ns", "3750 Ns", "7.5 Ns", 4, 2, 20, "A 0.15 kg ball traveling with a speed of 50 m/s is brought to rest in a catcher's mitt with an average force of 75 N. What is the maginutde of the impulse exerted by the mitt on the ball?" },
                    { 20, "125 kg m/s to the left", "0", "50 kg m/s to the right", "100 kg m/s to the right", 2, 2, 20, "A 5.0-kg cat travels to the left at 10 m/s and a 10-kg dog travels to the right at 5.0 m/s. The total momentum is" },
                    { 21, "Only (i) and (ii)", "Only (i) and (iii)", "Only (ii) and (iii)", "All of them", 3, 3, 20, "Which of the following are representations of the same molecule?\r\n(i) CH3CH2CH2CH2CH2CH2\r\n(ii) CH3\r\n     CH2CH2CH2CH2CH3\r\n(iii) CH2CH2CH2\r\n      CH3       CH2CH3" },
                    { 22, "They contain the maximum possible number of hydrogen atoms", "They are the most highly reactive organic compounds", "They have dissolved to the maximum extent possible", "They are good solvents", 1, 3, 20, "Which of the following explains why alkanes are called saturated hydrocarbons?" },
                    { 23, "Arenes", "Alkanes", "Alkenes", "Alkynes", 4, 3, 20, "Compounds which contain a carbon-carbon triple bond are classified as which of the following?" },
                    { 24, "Hydrogen", "Oxygen", "Nitrogen", "Carbon", 1, 3, 20, "In organic compounds a halogen atom can replace which of the following?" },
                    { 25, "Hexane", "Pentane", "Butane", "None of them", 3, 3, 20, "Which of the following is a gas at room temperature and pressure?" },
                    { 26, "3-methyl-3-propylheptane", "2-ethyl-2-propylhexane", "4-ethyl-4-methyloctane", "None of these", 3, 3, 20, "What is the IUPAC name of:\r\n       CH2CH2CH2CH3\r\nCH3CCH2CH3\r\n       CH2CH2CH3" },
                    { 27, "The substituent will prefer to be in the axial position", "The substituent has no particular preference for either the axial or equatorial position", "The situation will vary, depending on the identity of the substituent", "The substituent will prefer to be in the equatorial position", 4, 3, 20, "Which of the following is true when there is a single substituent on cyclohexane?" },
                    { 28, "7", "1", "5", "3", 3, 3, 20, "How many moles of oxygen are consumed by the complete combustion of one mole of propane, C3H8?" },
                    { 29, "Hexane", "Octane", "Nonane", "Heptane", 3, 3, 20, "Which of the following has the highest boiling point?" },
                    { 30, "Alcohols", "Aldehydes", "Amines", "All of these", 1, 3, 20, "In which of the following classes of organic compounds is an oxygen atom bonded to a hydrogen atom?" },
                    { 31, "First level producer", "First level consumer", "Secong level producer", "Third level consumer", 4, 4, 20, "A snake that eats a frog that has eaten an insect that fed on a plant is a" },
                    { 32, "Energy flows in one direction and nutrients recycle", "Energy is limited in the biosphere and nutrients are always available", "Nutrients flow in one direction and energy recycles", "Energy forms chemical compounds and nutrients are lost as heat", 0, 4, 20, "The movements of energy and nutrients through living systems are different because" },
                    { 33, "Average temperature of the ecosystem", "Type of soil in the ecosystem", "Number and kinds of predators in the ecosystem", "Concentration of oxygen in the ecosystem", 0, 4, 20, "Which is a biotic factor that affects the size of a population in a specific ecosystem?" },
                    { 34, "Mutualism because the flower provides the insect with food, and the insect pollinates the flower", "Parasitism because the insect lives off the nectar from the flower", "Commensalism because the insect doesn’t harm the flower, and the flower doesn’t benefit from the relationship", "Predation because the insect feeds on the flower", 1, 4, 20, "The symbiotic relationship between a flower and the insect that feeds on its nectar is an example of" },
                    { 35, "Primary succession is slow, and secondary succession is rapid", "Secondary succession begins on soil, and primary succession begins on newly exposed surfaces", "Primary succession modifies the environment, and secondary succession does not", "Secondary succession begins with lichens, and primary succession begins with trees", 2, 4, 20, "What is one difference between primary and secondary succession?" },
                    { 36, "The amount of available energy will increase because there will be fewer predators in the forest", "The amount of available energy will increase because there will be less competition from producers.", "The amount to available energy will decrease because fewer primary consumers will survive the lack of vegetation", "The amount of energy will remain constant because secondary consumers are not reliant on primary consumers", 3, 4, 20, "A forest fire destroys the majority of the trees in a state park. Which effect will this most likely have on secondary consumers in that ecosystem?" },
                    { 37, "The snakes introduced to the region dominated the habitat, forcing the mice to find another place to live", "The mice became prey to the intoduced snakes, allowing the snake population to increase but decreasing the mice population.", "The snakes introduced to the region competed with the mice for food, allowing the snake population to increase but decreasing the mice population.", "The people in the surrounding area set traps that killed the mice, allowing the snakes to live without any predators and therefore to increase the number.", 2, 4, 20, "A new species of snake was introduced to a tropical region. Scientists noticed a steady decline in the presence of field mice and an increase in the number of snakes. Which of these is the MOST LIKELY explanation for why the population size of each animal changed?" },
                    { 38, "Death rate may rise", "Birth rate may rise", "Population will grow faster", "Carrying capacity will change", 1, 4, 20, "If a population grows larger than the carrying capacity of the environment, the" },
                    { 39, "Biological magnification of toxic compounds", "Habitat fragmentation", "Invasive species", "Species preservation", 4, 4, 20, "All of the following are threats to biodiversity EXCEPT" },
                    { 40, "It would increase a small amount since the insect population would decrease", "It would remain about the same since the finches would change to a different habitat", "It would increase exponentially since the insects would have limited places to hide", "It would decrease considerably since the finches are specifically adapted to their niche", 4, 4, 20, "One species of Galapagos finches, the cactus finch, eats insects off cactus plants. A disease kills off most of the cacti in the Galapagos Islands. Which of these most likely would happen to the carrying capacity of the island?" },
                    { 41, "Right-click to reveal all icons", "Restart the computer", "It is not possible to open the program if no icons are on the desktop", "Click the start button and select the program icon from the menu", 4, 5, 20, "When you see no icons on the desktop, how can you open programs such as Microsoft Word?" },
                    { 42, "Creating documents", "Managing hardware and software resources", "Browsing the internet", "Playing games", 2, 5, 20, "What is the primary function of an operating system?" },
                    { 43, "I only", "I and II", "II only", "I, II, and III", 2, 5, 20, "When writing a program, what is true about program documentation?\r\nI. Program documentation is useful while writing the program.\r\nII. Program documentation is useful after the program is written.\r\nIII. Program documentation is not useful when run speed is a factor." },
                    { 44, "I only", "III only", "II and III", "I, II, and III", 4, 5, 20, "What is true about high-level programming languages?\r\nI. High-level languages are easier to debug and easier to code than machine code.\r\nII. High-level languages contain the most abstractions.\r\nIII. High-level languages are translated to machine code when executed on a computer." },
                    { 45, "Computer, transistor, graphics card", "Logic gate, transistor, graphics card", "Computer, video card, transistor", "Logic gate, video card, transistor", 3, 5, 20, "Hardware is built using multiple levels of abstractions. A computer is an abstraction. By making a computer an abstraction, it hides the complexity of the computer components, allowing the programmer to focus on programming\r\n\r\nWhich of the following lists hardware in order from high- to low-level hardware abstraction?" },
                    { 46, "An email indicates that a password is expiring and asks you to click a link to renew your password.", "An email from a familiar company, which has the exact look of previous emails from this company, reports that the current credit card information on file has expired, and has a link for you to reenter credit card information.", "An email from the IRS contains the correct IRS logo and asks you to submit your social security number so the IRS can mail an additional tax refund. Additionally, the email contains a warning that if this information is not filled out within 30 days the refund will be lost.", "An email from your credit card company with the correct bank logo indicates that there has been unusual activity on your credit card and to call the number on your card to confirm the purchase.", 4, 5, 20, "Which of the following examples LEAST likely indicates a phishing attack?" },
                    { 47, "Proxy server", "Domain name server", "Distributed denial-of-service (DDoS) attacks", "Phishing attack", 1, 5, 20, "To get their AP scores hours earlier, if not days earlier, than the scheduled release time, students will hide their IP address so they appear to be in a different time zone. What device can students use to hide their IP address?" },
                    { 48, "All of the above", "II, III, and IV", "I and III", "II and III", 4, 5, 20, "A computer can use 6 bits to store non-negative numbers. Which of the following will NOT give an overflow error?\r\n\r\nI. 64\r\nII. 63\r\nIII. 54\r\nIV. 89" },
                    { 49, "Roundoff error", "Overflow error", "DDoS attack", "Phishing", 1, 5, 20, "Two computers calculate the same equation:\r\na ← 1/3\r\n\r\nA second computer calculates\r\nb ← 1/3\r\n\r\nIf (a ≠ b), what error has occurred?" },
                    { 50, "Divide by zero error", "Short circuit", "Overflow error", "No error", 1, 5, 20, "What error is displayed by the algorithm below?\r\na ← 8\r\nb ← 5\r\nc ← b – 3\r\nd ← c – 2\r\nDISPLAY(a)\r\nDISPLAY(5/d)" }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "CourseId", "LessonId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, 1, 1, "", "" },
                    { 2, 1, 2, "", "" },
                    { 3, 1, 3, "", "" },
                    { 4, 1, 4, "", "" },
                    { 5, 1, 5, "", "" },
                    { 6, 1, 6, "", "" },
                    { 7, 2, 7, "", "" },
                    { 8, 2, 8, "", "" },
                    { 9, 2, 9, "", "" },
                    { 10, 2, 10, "", "" },
                    { 11, 2, 11, "", "" },
                    { 12, 2, 12, "", "" },
                    { 13, 3, 13, "", "" },
                    { 14, 3, 14, "", "" },
                    { 15, 3, 15, "", "" },
                    { 16, 3, 16, "", "" },
                    { 17, 3, 17, "", "" },
                    { 18, 3, 18, "", "" },
                    { 19, 4, 19, "", "" },
                    { 20, 4, 20, "", "" },
                    { 21, 4, 21, "", "" },
                    { 22, 4, 22, "", "" },
                    { 23, 4, 23, "", "" },
                    { 24, 4, 24, "", "" },
                    { 25, 5, 25, "", "" },
                    { 26, 5, 26, "", "" },
                    { 27, 5, 27, "", "" },
                    { 28, 5, 28, "", "" },
                    { 29, 5, 29, "", "" },
                    { 30, 5, 30, "", "" }
                });

            migrationBuilder.InsertData(
                table: "Homeworks",
                columns: new[] { "Id", "CourseId", "Deadline", "Description", "IsDone", "LessonId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2024, 5, 5), "", false, 1, "Homework 1" },
                    { 2, 1, new DateOnly(2024, 5, 5), "", false, 2, "Homework 1" },
                    { 3, 1, new DateOnly(2024, 5, 5), "", false, 3, "Homework 1" },
                    { 4, 1, new DateOnly(2024, 5, 5), "", false, 4, "Homework 1" },
                    { 5, 1, new DateOnly(2024, 5, 5), "", false, 5, "Homework 1" },
                    { 6, 1, new DateOnly(2024, 5, 5), "", false, 6, "Homework 1" },
                    { 7, 2, new DateOnly(2024, 5, 5), "", false, 7, "Homework 1" },
                    { 8, 2, new DateOnly(2024, 5, 5), "", false, 8, "Homework 1" },
                    { 9, 2, new DateOnly(2024, 5, 5), "", false, 9, "Homework 1" },
                    { 10, 2, new DateOnly(2024, 5, 5), "", false, 10, "Homework 1" },
                    { 11, 2, new DateOnly(2024, 5, 5), "", false, 11, "Homework 1" },
                    { 12, 2, new DateOnly(2024, 5, 5), "", false, 12, "Homework 1" },
                    { 13, 3, new DateOnly(2024, 5, 5), "", false, 13, "Homework 1" },
                    { 14, 3, new DateOnly(2024, 5, 5), "", false, 14, "Homework 1" },
                    { 15, 3, new DateOnly(2024, 5, 5), "", false, 15, "Homework 1" },
                    { 16, 3, new DateOnly(2024, 5, 5), "", false, 16, "Homework 1" },
                    { 17, 3, new DateOnly(2024, 5, 5), "", false, 17, "Homework 1" },
                    { 18, 3, new DateOnly(2024, 5, 5), "", false, 18, "Homework 1" },
                    { 19, 4, new DateOnly(2024, 5, 5), "", false, 19, "Homework 1" },
                    { 20, 4, new DateOnly(2024, 5, 5), "", false, 20, "Homework 1" },
                    { 21, 4, new DateOnly(2024, 5, 5), "", false, 21, "Homework 1" },
                    { 22, 4, new DateOnly(2024, 5, 5), "", false, 22, "Homework 1" },
                    { 23, 4, new DateOnly(2024, 5, 5), "", false, 23, "Homework 1" },
                    { 24, 4, new DateOnly(2024, 5, 5), "", false, 24, "Homework 1" },
                    { 25, 5, new DateOnly(2024, 5, 5), "", false, 25, "Homework 1" },
                    { 26, 5, new DateOnly(2024, 5, 5), "", false, 26, "Homework 1" },
                    { 27, 5, new DateOnly(2024, 5, 5), "", false, 27, "Homework 1" },
                    { 28, 5, new DateOnly(2024, 5, 5), "", false, 28, "Homework 1" },
                    { 29, 5, new DateOnly(2024, 5, 5), "", false, 29, "Homework 1" },
                    { 30, 5, new DateOnly(2024, 5, 5), "", false, 30, "Homework 1" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CourseId", "LessonId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, 1, 1, "What is a variable", "What is a variable.mp4" },
                    { 2, 1, 2, "How to evaluate expressions with two variables", "How to evaluate expressions with two variables.mp4" },
                    { 3, 1, 3, "How to write basic expressions with variables", "How to write basic expressions with variables.mp4" },
                    { 4, 1, 4, "Combining like terms introduction", "Combining like terms introduction.mp4" },
                    { 5, 1, 5, "How to use the distributive property with variables", "How to use the distributive property with variables.mp4" },
                    { 6, 1, 6, "How to find equivalent expressions by combining like terms", "How to find equivalent expressions by combining like terms.mp4" },
                    { 7, 2, 7, "Introduction to physics", "Introduction to physics.mp4" },
                    { 8, 2, 8, "Distance and displacement introduction", "Distance and displacement introduction.mp4" },
                    { 9, 2, 9, "Average velocity and speed worked example", "Average velocity and speed worked example.mp4" },
                    { 10, 2, 10, "Instantaneous speed and velocity", "Instantaneous speed and velocity.mp4" },
                    { 11, 2, 11, "Acceleration", "Acceleration.mp4" },
                    { 12, 2, 12, "Choosing kinematic equations", "Choosing kinematic equations.mp4" },
                    { 13, 3, 13, "Average atomic mass", "Average atomic mass.mp4" },
                    { 14, 3, 14, "Isotopes", "Isotopes.mp4" },
                    { 15, 3, 15, "Empirical, molecular, and structural formulas", "Empirical, molecular, and structural formulas.mp4" },
                    { 16, 3, 16, "Calculating the mass of a substance in a mixture", "Calculating the mass of a substance in a mixture.mp4" },
                    { 17, 3, 17, "Shells, subshells, and orbitals", "Shells, subshells, and orbitals.mp4" },
                    { 18, 3, 18, "Periodic trends and Coulomb's law", "Periodic trends and Coulomb's law.mp4" },
                    { 19, 4, 19, "Biology overview", "Biology overview.mp4" },
                    { 20, 4, 20, "Elements and atoms", "Elements and atoms.mp4" },
                    { 21, 4, 21, "Hydrogen bonding in water", "Hydrogen bonding in water.mp4" },
                    { 22, 4, 22, "Introduction to pH", "Introduction to pH.mp4" },
                    { 23, 4, 23, "Scale of cells", "Scale of cells.mp4" },
                    { 24, 4, 24, "Introduction to the cell", "Introduction to the cell.mp4" },
                    { 25, 5, 25, "", "" },
                    { 26, 5, 26, "", "" },
                    { 27, 5, 27, "", "" },
                    { 28, 5, 28, "", "" },
                    { 29, 5, 29, "", "" },
                    { 30, 5, 30, "", "" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CourseId", "HomeworkId", "LessonId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "", "" },
                    { 2, 1, 2, 2, "", "" },
                    { 3, 1, 3, 3, "", "" },
                    { 4, 1, 4, 4, "", "" },
                    { 5, 1, 5, 5, "", "" },
                    { 6, 1, 6, 6, "", "" },
                    { 7, 2, 7, 7, "", "" },
                    { 8, 2, 8, 8, "", "" },
                    { 9, 2, 9, 9, "", "" },
                    { 10, 2, 10, 10, "", "" },
                    { 11, 2, 11, 11, "", "" },
                    { 12, 2, 12, 12, "", "" },
                    { 13, 3, 13, 13, "", "" },
                    { 14, 3, 14, 14, "", "" },
                    { 15, 3, 15, 15, "", "" },
                    { 16, 3, 16, 16, "", "" },
                    { 17, 3, 17, 17, "", "" },
                    { 18, 3, 18, 18, "", "" },
                    { 19, 4, 19, 19, "", "" },
                    { 20, 4, 20, 20, "", "" },
                    { 21, 4, 21, 21, "", "" },
                    { 22, 4, 22, 22, "", "" },
                    { 23, 4, 23, 23, "", "" },
                    { 24, 4, 24, 24, "", "" },
                    { 25, 5, 25, 25, "", "" },
                    { 26, 5, 26, 26, "", "" },
                    { 27, 5, 27, 27, "", "" },
                    { 28, 5, 28, 28, "", "" },
                    { 29, 5, 29, 29, "", "" },
                    { 30, 5, 30, 30, "", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docs_CourseId",
                table: "Docs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_LessonId",
                table: "Docs",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_CourseId",
                table: "Homeworks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_LessonId",
                table: "Homeworks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_HomeworkId",
                table: "Materials",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_LessonId",
                table: "Materials",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CourseId",
                table: "Tests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CourseId",
                table: "Videos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_LessonId",
                table: "Videos",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
