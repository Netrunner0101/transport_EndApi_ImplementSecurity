using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id_customer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id_customer);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id_delivery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroDelivery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTransfert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dateDelivery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id_delivery);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    id_drive = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.id_drive);
                });

            migrationBuilder.CreateTable(
                name: "transporter",
                columns: table => new
                {
                    id_transporter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transporter", x => x.id_transporter);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "CustomerModelDalDeliveryModelDal",
                columns: table => new
                {
                    customersid_customer = table.Column<int>(type: "int", nullable: false),
                    deliveriesid_delivery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerModelDalDeliveryModelDal", x => new { x.customersid_customer, x.deliveriesid_delivery });
                    table.ForeignKey(
                        name: "FK_CustomerModelDalDeliveryModelDal_customer_customersid_customer",
                        column: x => x.customersid_customer,
                        principalTable: "customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerModelDalDeliveryModelDal_delivery_deliveriesid_delivery",
                        column: x => x.deliveriesid_delivery,
                        principalTable: "delivery",
                        principalColumn: "id_delivery",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryModelDalTransporterModelDal",
                columns: table => new
                {
                    deliveriesid_delivery = table.Column<int>(type: "int", nullable: false),
                    transportersid_transporter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryModelDalTransporterModelDal", x => new { x.deliveriesid_delivery, x.transportersid_transporter });
                    table.ForeignKey(
                        name: "FK_DeliveryModelDalTransporterModelDal_delivery_deliveriesid_delivery",
                        column: x => x.deliveriesid_delivery,
                        principalTable: "delivery",
                        principalColumn: "id_delivery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryModelDalTransporterModelDal_transporter_transportersid_transporter",
                        column: x => x.transportersid_transporter,
                        principalTable: "transporter",
                        principalColumn: "id_transporter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverModelDalTransporterModelDal",
                columns: table => new
                {
                    driversid_drive = table.Column<int>(type: "int", nullable: false),
                    transportersid_transporter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverModelDalTransporterModelDal", x => new { x.driversid_drive, x.transportersid_transporter });
                    table.ForeignKey(
                        name: "FK_DriverModelDalTransporterModelDal_driver_driversid_drive",
                        column: x => x.driversid_drive,
                        principalTable: "driver",
                        principalColumn: "id_drive",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverModelDalTransporterModelDal_transporter_transportersid_transporter",
                        column: x => x.transportersid_transporter,
                        principalTable: "transporter",
                        principalColumn: "id_transporter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "id_customer", "adress", "email", "name", "phoneNumber", "vat" },
                values: new object[,]
                {
                    { 1, "rue de Tatoinne", "obi@gmail.com", "obiwan", "045823232", "68793" },
                    { 2, "rue de Coruscant", "anakin@gmail.com", "anaki", "04598382832", "943249" }
                });

            migrationBuilder.InsertData(
                table: "delivery",
                columns: new[] { "id_delivery", "adress", "dateDelivery", "dateTransfert", "numeroDelivery", "remarks", "weight" },
                values: new object[,]
                {
                    { 1, "Rue des amazon", new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZIH313213", "have the customs", 968 },
                    { 2, "Rue des BPOST", new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FEDEX02133", "All are packet", 563 }
                });

            migrationBuilder.InsertData(
                table: "driver",
                columns: new[] { "id_drive", "email", "name", "phoneNumber" },
                values: new object[,]
                {
                    { 1, "alphonso@sctrans.com", "Alphonso", "06323156" },
                    { 2, "Karl@gemini.com", "Karl", "09283921" }
                });

            migrationBuilder.InsertData(
                table: "transporter",
                columns: new[] { "id_transporter", "adress", "email", "name", "phoneNumber" },
                values: new object[,]
                {
                    { 1, "rue des alouettes ", "info@sctrans.com", "sctrans", "06273321" },
                    { 2, "rue des avions ", "info@geminitransport.com", "geminitransport", "06982313" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModelDalDeliveryModelDal_deliveriesid_delivery",
                table: "CustomerModelDalDeliveryModelDal",
                column: "deliveriesid_delivery");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryModelDalTransporterModelDal_transportersid_transporter",
                table: "DeliveryModelDalTransporterModelDal",
                column: "transportersid_transporter");

            migrationBuilder.CreateIndex(
                name: "IX_DriverModelDalTransporterModelDal_transportersid_transporter",
                table: "DriverModelDalTransporterModelDal",
                column: "transportersid_transporter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerModelDalDeliveryModelDal");

            migrationBuilder.DropTable(
                name: "DeliveryModelDalTransporterModelDal");

            migrationBuilder.DropTable(
                name: "DriverModelDalTransporterModelDal");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropTable(
                name: "driver");

            migrationBuilder.DropTable(
                name: "transporter");
        }
    }
}
