using System.Diagnostics;
using FluentAssertions;
using Generics.RealWorld.Serialization.Support;
using NUnit.Framework;

namespace Generics.RealWorld.Serialization.Test {
   [TestFixture]
   public class SerializeInvoiceTests {
      private string _invoiceXml;
      private Invoice _invoice;

      [SetUp]
      public void BeforeEachTest() {
         _invoice = new Invoice {
            InvoiceNumber = "12345",
            ItemsOrders = new[] {
               new Item {ID = "1", ItemPrice = 10m},
               new Item {ID = "2", ItemPrice = 20m},
               new Item {ID = "3", ItemPrice = 30m}
            }
         };

         _invoiceXml = @"<?xml version='1.0' encoding='utf-8'?>
                               <Invoice>
                                  <ItemsOrders>
                                      <Item><ID>1</ID><ItemPrice>10</ItemPrice></Item>
                                      <Item><ID>2</ID><ItemPrice>20</ItemPrice></Item>
                                      <Item><ID>3</ID><ItemPrice>30</ItemPrice></Item>
                                  </ItemsOrders>
                                  <InvoiceNumber>12345</InvoiceNumber>
                               </Invoice>";
      }

      [Test]
      public void TestSerialize() {
         XmlProcessor processor = new XmlProcessor();

         string invoiceXml = processor.Serialize( _invoice );

         invoiceXml.Should().NotBeEmpty();
         Debug.Write( invoiceXml );
         // Yes, this is pretty low bar for a passing unit test, but comparing XML is beyond the scope of this project
      }

      [Test]
      public void TestDeserialize() {
         XmlProcessor processor = new XmlProcessor();

         Invoice invoiceXml = processor.Deserialize<Invoice>( _invoiceXml );

         invoiceXml.Should().NotBeNull();
         invoiceXml.ItemsOrders.Should().NotBeEmpty().And.HaveCount( 3 );
         invoiceXml.InvoiceNumber.Should().Be( "12345" );
      }
   }
}