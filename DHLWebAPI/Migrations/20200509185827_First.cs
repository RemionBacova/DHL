using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DHLWebAPI.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_tool_permission",
                columns: table => new
                {
                    IdProfile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileCode = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_tool__120435C18A2526A2", x => x.IdProfile);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_type",
                columns: table => new
                {
                    IdUserType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_type", x => x.IdUserType);
                });

            migrationBuilder.CreateTable(
                name: "tbl_profile_permission",
                columns: table => new
                {
                    ProfileSetName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IdProfile = table.Column<int>(type: "int", nullable: false),
                    ProfileCode = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_prof__ABF29A35D7291A0D", x => x.ProfileSetName);
                    table.ForeignKey(
                        name: "FK__tbl_profi__IdPro__75A278F5",
                        column: x => x.IdProfile,
                        principalTable: "tbl_tool_permission",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tools",
                columns: table => new
                {
                    IdTool = table.Column<int>(type: "int", unicode: false, maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ToolKey = table.Column<byte[]>(type: "binary(32)", fixedLength: true, maxLength: 32, nullable: false),
                    ToolStatus = table.Column<bool>(type: "bit", nullable: false),
                    IdProfile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tools", x => x.IdTool);
                    table.ForeignKey(
                        name: "FK__tbl_tools__IdPro__7A672E12",
                        column: x => x.IdProfile,
                        principalTable: "tbl_tool_permission",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    TitleOfCourtesy = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Hiredate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK__tbl_users__UserT__7F2BE32F",
                        column: x => x.UserType,
                        principalTable: "tbl_user_type",
                        principalColumn: "IdUserType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_address_type",
                columns: table => new
                {
                    IdAddressType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressType = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_address_type", x => x.IdAddressType);
                    table.ForeignKey(
                        name: "FK__tbl_addre__Inser__5070F446",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_addre__Updat__5165187F",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_card_status",
                columns: table => new
                {
                    IdCardStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardStatus = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_card_status", x => x.IdCardStatus);
                    table.ForeignKey(
                        name: "FK__tbl_card___Updat__52593CB8",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customer_status",
                columns: table => new
                {
                    IdCustomerStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customer_status", x => x.IdCustomerStatus);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Inser__60A75C0F",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Updat__619B8048",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customer_type",
                columns: table => new
                {
                    IdCustomerType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customer_type", x => x.IdCustomerType);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Inser__628FA481",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Updat__6383C8BA",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_discount_type",
                columns: table => new
                {
                    IdDiscountType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountTypeTitle = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_discount_type", x => x.IdDiscountType);
                    table.ForeignKey(
                        name: "FK__tbl_disco__Inser__6C190EBB",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_disco__Updat__6D0D32F4",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertData = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK__tbl_produ__Inser__73BA3083",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_produ__Updat__74AE54BC",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_address",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAddressType = table.Column<int>(type: "int", nullable: false),
                    AddressLabel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    PostAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PostAddressNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PostIntern = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    OpenTimeStart = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    OpenTimeEnd = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    LunchTimeStart = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    LunchTimeEnd = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    ContactName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_address", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK__tbl_addre__IdAdd__4F7CD00D",
                        column: x => x.IdAddressType,
                        principalTable: "tbl_address_type",
                        principalColumn: "IdAddressType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_discounts",
                columns: table => new
                {
                    IdDiscount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountTitle = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DiscountDescription = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    DiscountPerc = table.Column<float>(type: "real", nullable: false),
                    DiscountStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    DiscountEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    DiscountToActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_discounts", x => x.IdDiscount);
                    table.ForeignKey(
                        name: "FK__tbl_disco__Disco__6E01572D",
                        column: x => x.DiscountType,
                        principalTable: "tbl_discount_type",
                        principalColumn: "IdDiscountType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_disco__Inser__6EF57B66",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_disco__Updat__6FE99F9F",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    CustomerStatus = table.Column<int>(type: "int", nullable: false),
                    Channel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    IVA = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    SDI = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    ContactName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    FiscalCode = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    PEC = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdDiscount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customers", x => x.IdCustomer);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Custo__6477ECF3",
                        column: x => x.CustomerType,
                        principalTable: "tbl_customer_type",
                        principalColumn: "IdCustomerType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Custo__656C112C",
                        column: x => x.CustomerStatus,
                        principalTable: "tbl_customer_status",
                        principalColumn: "IdCustomerStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__IdDis__66603565",
                        column: x => x.IdDiscount,
                        principalTable: "tbl_discounts",
                        principalColumn: "IdDiscount",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Inser__6754599E",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Updat__68487DD7",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_product_discount",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    IdDiscount = table.Column<int>(type: "int", nullable: false),
                    CodeForActive = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_prod__12E34877E8452339", x => new { x.IdProduct, x.IdDiscount });
                    table.ForeignKey(
                        name: "FK__tbl_produ__IdDis__70DDC3D8",
                        column: x => x.IdDiscount,
                        principalTable: "tbl_discounts",
                        principalColumn: "IdDiscount",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_produ__Inser__71D1E811",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_product_discount_tbl_products",
                        column: x => x.IdProduct,
                        principalTable: "tbl_products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cards",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    IdCard = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    BalanceAvailable = table.Column<float>(type: "real", nullable: false),
                    CardStatus = table.Column<int>(type: "int", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_card__DB43864A309309D5", x => x.IdCustomer);
                    table.UniqueConstraint("AK_tbl_cards_IdCard", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK__tbl_cards__CardS__534D60F1",
                        column: x => x.CardStatus,
                        principalTable: "tbl_card_status",
                        principalColumn: "IdCardStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_cards__IdCus__5441852A",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_cards__Inser__5535A963",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_cards__Updat__5629CD9C",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customer_address",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_cust__345F797D18461953", x => new { x.IdCustomer, x.IdAddress });
                    table.ForeignKey(
                        name: "FK__tbl_custo__IdAdd__571DF1D5",
                        column: x => x.IdAddress,
                        principalTable: "tbl_address",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__IdCus__5812160E",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Inser__59063A47",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Updat__59FA5E80",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customer_discount",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    IdDiscount = table.Column<int>(type: "int", nullable: false),
                    CodeForActive = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_cust__E72988E9763FF381", x => new { x.IdCustomer, x.IdDiscount });
                    table.ForeignKey(
                        name: "FK__tbl_custo__IdCus__5AEE82B9",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__IdDis__5BE2A6F2",
                        column: x => x.IdDiscount,
                        principalTable: "tbl_discounts",
                        principalColumn: "IdDiscount",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Inser__5CD6CB2B",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customer_logs",
                columns: table => new
                {
                    PID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    CustomerXML = table.Column<string>(type: "xml", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdTool = table.Column<int>(type: "int", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customer_logs", x => x.PID);
                    table.ForeignKey(
                        name: "FK__tbl_custo__IdCus__5DCAEF64",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_custo__IdToo__5EBF139D",
                        column: x => x.IdTool,
                        principalTable: "tbl_tools",
                        principalColumn: "IdTool",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__tbl_custo__Inser__5FB337D6",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_shipments",
                columns: table => new
                {
                    PID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCostumer = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    AWB = table.Column<long>(type: "bigint", nullable: false),
                    DatetimeCreation = table.Column<DateTime>(type: "datetime", nullable: false),
                    ImmediateInvoicing = table.Column<bool>(type: "bit", nullable: false),
                    CheckPointFound = table.Column<bool>(type: "bit", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalInvoice = table.Column<float>(type: "real", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdTool = table.Column<int>(type: "int", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_shipments", x => x.PID);
                    table.ForeignKey(
                        name: "FK__tbl_shipm__IdCos__76969D2E",
                        column: x => x.IdCostumer,
                        principalTable: "tbl_customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__tbl_shipm__IdToo__778AC167",
                        column: x => x.IdTool,
                        principalTable: "tbl_tools",
                        principalColumn: "IdTool",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__tbl_shipm__Inser__787EE5A0",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_shipm__Updat__797309D9",
                        column: x => x.UpdateBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_transaction_logs",
                columns: table => new
                {
                    PID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    IdCard = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TransactionType = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionID = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: false),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    AWB = table.Column<long>(type: "bigint", nullable: true),
                    AWBStatus = table.Column<bool>(type: "bit", nullable: false),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdTool = table.Column<int>(type: "int", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_transaction_logs", x => x.PID);
                    table.ForeignKey(
                        name: "FK__tbl_trans__IdCar__7B5B524B",
                        column: x => x.IdCard,
                        principalTable: "tbl_cards",
                        principalColumn: "IdCard",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_trans__IdCus__7C4F7684",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_trans__IdToo__7D439ABD",
                        column: x => x.IdTool,
                        principalTable: "tbl_tools",
                        principalColumn: "IdTool",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__tbl_trans__Inser__7E37BEF6",
                        column: x => x.InsertBy,
                        principalTable: "tbl_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_IdAddressType",
                table: "tbl_address",
                column: "IdAddressType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_type_InsertBy",
                table: "tbl_address_type",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_type_UpdateBy",
                table: "tbl_address_type",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_card_status_UpdateBy",
                table: "tbl_card_status",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cards_CardStatus",
                table: "tbl_cards",
                column: "CardStatus");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cards_InsertBy",
                table: "tbl_cards",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cards_UpdateBy",
                table: "tbl_cards",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "UQ__tbl_card__3B7B33C30302E6B9",
                table: "tbl_cards",
                column: "IdCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_address_IdAddress",
                table: "tbl_customer_address",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_address_InsertBy",
                table: "tbl_customer_address",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_address_UpdateBy",
                table: "tbl_customer_address",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_discount_IdDiscount",
                table: "tbl_customer_discount",
                column: "IdDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_discount_InsertBy",
                table: "tbl_customer_discount",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_logs_IdCustomer",
                table: "tbl_customer_logs",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_logs_IdTool",
                table: "tbl_customer_logs",
                column: "IdTool");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_logs_InsertBy",
                table: "tbl_customer_logs",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_status_InsertBy",
                table: "tbl_customer_status",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_status_UpdateBy",
                table: "tbl_customer_status",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_type_InsertBy",
                table: "tbl_customer_type",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_type_UpdateBy",
                table: "tbl_customer_type",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_CustomerStatus",
                table: "tbl_customers",
                column: "CustomerStatus");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_CustomerType",
                table: "tbl_customers",
                column: "CustomerType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_IdDiscount",
                table: "tbl_customers",
                column: "IdDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_InsertBy",
                table: "tbl_customers",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_UpdateBy",
                table: "tbl_customers",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_discount_type_InsertBy",
                table: "tbl_discount_type",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_discount_type_UpdateBy",
                table: "tbl_discount_type",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_discounts_DiscountType",
                table: "tbl_discounts",
                column: "DiscountType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_discounts_InsertBy",
                table: "tbl_discounts",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_discounts_UpdateBy",
                table: "tbl_discounts",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_discount_IdDiscount",
                table: "tbl_product_discount",
                column: "IdDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_discount_InsertBy",
                table: "tbl_product_discount",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_InsertBy",
                table: "tbl_products",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_UpdatedBy",
                table: "tbl_products",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_profile_permission_IdProfile",
                table: "tbl_profile_permission",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shipments_IdCostumer",
                table: "tbl_shipments",
                column: "IdCostumer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shipments_IdTool",
                table: "tbl_shipments",
                column: "IdTool");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shipments_InsertBy",
                table: "tbl_shipments",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shipments_UpdateBy",
                table: "tbl_shipments",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_tools_IdProfile",
                table: "tbl_tools",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_logs_IdCard",
                table: "tbl_transaction_logs",
                column: "IdCard");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_logs_IdCustomer",
                table: "tbl_transaction_logs",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_logs_IdTool",
                table: "tbl_transaction_logs",
                column: "IdTool");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_logs_InsertBy",
                table: "tbl_transaction_logs",
                column: "InsertBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_UserType",
                table: "tbl_users",
                column: "UserType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_customer_address");

            migrationBuilder.DropTable(
                name: "tbl_customer_discount");

            migrationBuilder.DropTable(
                name: "tbl_customer_logs");

            migrationBuilder.DropTable(
                name: "tbl_product_discount");

            migrationBuilder.DropTable(
                name: "tbl_profile_permission");

            migrationBuilder.DropTable(
                name: "tbl_shipments");

            migrationBuilder.DropTable(
                name: "tbl_transaction_logs");

            migrationBuilder.DropTable(
                name: "tbl_address");

            migrationBuilder.DropTable(
                name: "tbl_products");

            migrationBuilder.DropTable(
                name: "tbl_cards");

            migrationBuilder.DropTable(
                name: "tbl_tools");

            migrationBuilder.DropTable(
                name: "tbl_address_type");

            migrationBuilder.DropTable(
                name: "tbl_card_status");

            migrationBuilder.DropTable(
                name: "tbl_customers");

            migrationBuilder.DropTable(
                name: "tbl_tool_permission");

            migrationBuilder.DropTable(
                name: "tbl_customer_type");

            migrationBuilder.DropTable(
                name: "tbl_customer_status");

            migrationBuilder.DropTable(
                name: "tbl_discounts");

            migrationBuilder.DropTable(
                name: "tbl_discount_type");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_user_type");
        }
    }
}
