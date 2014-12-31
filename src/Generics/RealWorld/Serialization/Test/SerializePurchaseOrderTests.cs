using System.Diagnostics;
using FluentAssertions;
using Generics.RealWorld.Serialization.Support;
using NUnit.Framework;

namespace Generics.RealWorld.Serialization.Test {
   [TestFixture]
   public class SerializePurchaseOrderTests {
      private string _purchaseOrderXml;
      private PurchaseOrder _purchaseOrder;

      [SetUp]
      public void BeforeEachTest() {
         _purchaseOrder = new PurchaseOrder {
            OrderNumber = "12345",
            ItemsOrders = new[] {
               new Item {ID = "1", ItemPrice = 10m},
               new Item {ID = "2", ItemPrice = 20m},
               new Item {ID = "3", ItemPrice = 30m}
            }
         };

         _purchaseOrderXml = @"<?xml version='1.0' encoding='utf-8'?>
                               <PurchaseOrder>
                                  <ItemsOrders>
                                      <Item><ID>1</ID><ItemPrice>10</ItemPrice></Item>
                                      <Item><ID>2</ID><ItemPrice>20</ItemPrice></Item>
                                      <Item><ID>3</ID><ItemPrice>30</ItemPrice></Item>
                                  </ItemsOrders>
                                  <OrderNumber>12345</OrderNumber>
                               </PurchaseOrder>";
      }

      [Test]
      public void TestSerialize() {
         XmlProcessor processor = new XmlProcessor();

         string poXml = processor.Serialize( _purchaseOrder );

         poXml.Should().NotBeEmpty();
         Debug.Write( poXml );
         // Yes, this is pretty low bar for a passing unit test, but comparing XML is beyond the scope of this project
      }

      [Test]
      public void TestSerializeUsingExtensionMethod() {
         string purchaseOrderXml = _purchaseOrder.Serialize();

         purchaseOrderXml.Should().NotBeEmpty();
         Debug.Write( purchaseOrderXml );
         // Yes, this is pretty low bar for a passing unit test, but comparing XML is beyond the scope of this project
      }

      [Test]
      public void TestDeserialize() {
         XmlProcessor processor = new XmlProcessor();

         PurchaseOrder po = processor.Deserialize<PurchaseOrder>( _purchaseOrderXml );

         po.Should().NotBeNull();
         po.ItemsOrders.Should().NotBeEmpty().And.HaveCount( 3 );
         po.OrderNumber.Should().Be( "12345" );
      }

      [Test]
      public void TestDeserializeUsingExtensionMethod() {
         PurchaseOrder purchaseOrderXml = _purchaseOrderXml.Deserialize<PurchaseOrder>();

         purchaseOrderXml.Should().NotBeNull();
         purchaseOrderXml.ItemsOrders.Should().NotBeEmpty().And.HaveCount( 3 );
         purchaseOrderXml.OrderNumber.Should().Be( "12345" );
      }
   }
}