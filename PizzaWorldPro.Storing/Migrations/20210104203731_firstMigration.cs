using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorldPro.Storing.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUser = table.Column<int>(type: "int", nullable: false),
                    IsAnEmployee = table.Column<bool>(type: "bit", nullable: false),
                    SelectedStoreEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Users_Stores_SelectedStoreEntityId",
                        column: x => x.SelectedStoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPrice = table.Column<double>(type: "float", nullable: false),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: true),
                    UserEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APizzaModel",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaPrice = table.Column<double>(type: "float", nullable: false),
                    CrustEntityId = table.Column<long>(type: "bigint", nullable: true),
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: true),
                    SizeEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaModel", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_APizzaModel_Crusts_CrustEntityId",
                        column: x => x.CrustEntityId,
                        principalTable: "Crusts",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APizzaModel_Orders_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Orders",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APizzaModel_Sizes_SizeEntityId",
                        column: x => x.SizeEntityId,
                        principalTable: "Sizes",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APizzaModelToppings",
                columns: table => new
                {
                    PizzaEntityId = table.Column<long>(type: "bigint", nullable: false),
                    PizzaToppingsEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaModelToppings", x => new { x.PizzaEntityId, x.PizzaToppingsEntityId });
                    table.ForeignKey(
                        name: "FK_APizzaModelToppings_APizzaModel_PizzaEntityId",
                        column: x => x.PizzaEntityId,
                        principalTable: "APizzaModel",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaModelToppings_Toppings_PizzaToppingsEntityId",
                        column: x => x.PizzaToppingsEntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityId", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { 1L, "Regular", 1.0 },
                    { 2L, "Thin-Flat", 1.25 },
                    { 3L, "Stuffed", 1.5 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityId", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { 1L, "Piccola", 1.0 },
                    { 2L, "Medio", 1.25 },
                    { 3L, "Familiare", 1.5 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "The Vaticano Pizzas" },
                    { 2L, "The Corner Pizzas" },
                    { 3L, "The Negozio Pizzas" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { 14L, "Baby Spinach", 2.0 },
                    { 13L, "Basil", 3.0 },
                    { 12L, "Red Peppers", 0.65000000000000002 },
                    { 10L, "Green Peppers", 0.78000000000000003 },
                    { 9L, "Bacon", 1.25 },
                    { 8L, "Onions", 0.55000000000000004 },
                    { 3L, "Mozarella", 0.98999999999999999 },
                    { 6L, "Pepperoni", 1.25 },
                    { 5L, "Tomatoes", 1.0 },
                    { 4L, "Green Olives", 0.75 },
                    { 15L, "Black Olives", 1.0 },
                    { 2L, "Ham", 0.80000000000000004 },
                    { 1L, "Pineapple", 1.5 },
                    { 7L, "Mushrooms", 1.1000000000000001 },
                    { 16L, "Cheese-feta", 2.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModel_CrustEntityId",
                table: "APizzaModel",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModel_OrderEntityId",
                table: "APizzaModel",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModel_SizeEntityId",
                table: "APizzaModel",
                column: "SizeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModelToppings_PizzaToppingsEntityId",
                table: "APizzaModelToppings",
                column: "PizzaToppingsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreEntityId",
                table: "Orders",
                column: "StoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserEntityId",
                table: "Orders",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedStoreEntityId",
                table: "Users",
                column: "SelectedStoreEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APizzaModelToppings");

            migrationBuilder.DropTable(
                name: "APizzaModel");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
