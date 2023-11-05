using Microsoft.AspNetCore.Mvc;
using orderManagement.webApi.DataContext;
using orderManagement.webApi.Model;

namespace orderManagement.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        #region Member Functions
        private readonly IOrderService _orderService;
        #endregion

        #region Constructor
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion


        #region Get All Order Details 
        [HttpGet]
        [Route("GetAllOrderDetails")]
        public IActionResult GetAllOrderDetails()
        {
            try
            {
                var orderDetails = _orderService.GetAllOrderDetails();
                if (orderDetails == null)
                {
                    return NotFound();
                }
                return new JsonResult(orderDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        #endregion

        #region Add Order Details
        /// <summary>
        /// To Add the New Order details
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOrderDetails")]
        public IActionResult AddOrderDetails([FromBody] OrderDetails order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data");
            }

            try
            {
                _orderService.AddOrder(order);
                return Ok("Created Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        #endregion

        #region updateOrderDetails
        /// <summary>
        /// Update the order Details based on the order id
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateOrderDetailsById")]
        public IActionResult UpdateOrderDetailsById([FromBody] OrderDetails order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data"); 
            }

            try
            {
                _orderService.UpdateOrder(order.OrderId, order);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        #endregion

        #region  DeleteOrder
        /// <summary>
        /// Delete the order Details Based on the Order Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteOrderById")]
        public IActionResult DeleteOrderById([FromBody]List<int> orderIds)
        {
            try
            {
                _orderService.DeleteOrder(orderIds);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        #endregion

    }
}
