using System;
using TradingEngineCommonCS.Records;

namespace TradingEngineCommonCS
{
    public sealed class ProtoAdapter
    {
        public static OrderActionResponse OrderActionResponse_FromProto(TradingEngine.Proto.OrderActionResponse ar)
        {
            return new OrderActionResponse(ResponseType_FromProto(ar.ResponseTypeCase) ,ar.ResponseId, 
                OrderNewStatus_FromProto(ar.OrderNewResponse), OrderCancelStatus_FromProto(ar.OrderCancelResponse),
                OrderFillStatus_FromProto(ar.OrderFillResponse));
        }

        private static ResponseType ResponseType_FromProto(TradingEngine.Proto.OrderActionResponse.ResponseTypeOneofCase responseType)
        {
            return responseType switch
            {
                TradingEngine.Proto.OrderActionResponse.ResponseTypeOneofCase.OrderCancelResponse => ResponseType.OrderCancelStatus,
                TradingEngine.Proto.OrderActionResponse.ResponseTypeOneofCase.OrderFillResponse => ResponseType.OrderFillStatus,
                TradingEngine.Proto.OrderActionResponse.ResponseTypeOneofCase.OrderNewResponse => ResponseType.OrderNewStatus,
                _ => throw new InvalidOperationException($"Unknown ResponseType ({responseType})"),
            };
        }

        public static OrderNewStatus OrderNewStatus_FromProto(TradingEngine.Proto.OrderNewStatus ons)
        {
            if (ons == null)
                return null;
            return new OrderNewStatus();
        }

        public static OrderCancelStatus OrderCancelStatus_FromProto(TradingEngine.Proto.OrderCancelStatus ocs)
        {
            if (ocs == null)
                return null;
            return new OrderCancelStatus();
        }

        public static OrderFillStatus OrderFillStatus_FromProto(TradingEngine.Proto.OrderFillStatus ofs)
        {
            if (ofs == null)
                return null;
            return new OrderFillStatus();
        }

        public static TradingEngine.Proto.OrderActionUpdate OrderActionUpdate_ToProto(OrderActionUpdate oau)
        {
            return oau.UpdateType switch
            {
                UpdateType.OrderNew => new TradingEngine.Proto.OrderActionUpdate() { OrderNewUpdate = OrderNewUpdate_ToProto(oau.OrderNew), },
                UpdateType.OrderCancel => new TradingEngine.Proto.OrderActionUpdate() { OrderCancelUpdate = OrderCancelUpdate_ToProto(oau.OrderCancel), },
                _ => throw new InvalidOperationException($"Unknown UpdateType ({oau.UpdateType})"),
            };
        }

        private static TradingEngine.Proto.OrderCancel OrderCancelUpdate_ToProto(OrderCancel orderCancel)
        {
            var now = DateTime.Now;
            return new TradingEngine.Proto.OrderCancel()
            {
                OrderInformation = OrderInformation_ToProto(orderCancel.OrderInformation),
                SendTime = Timestamp_ToProto(now),
            };
        }

        private static Google.Protobuf.WellKnownTypes.Timestamp Timestamp_ToProto(DateTime now)
        {
            return Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(now);
        }

        private static TradingEngine.Proto.OrderNew OrderNewUpdate_ToProto(OrderNew orderNew)
        {
            // SendTime is time we send, not time we received.
            var now = DateTime.Now;
            return new TradingEngine.Proto.OrderNew()
            {
                SendTime = Timestamp_ToProto(now),
                IsBuy = orderNew.IsBuy,
                OrderInformation = OrderInformation_ToProto(orderNew.OrderInformation),
                Price = orderNew.Price,
                Quantity = orderNew.Quantity,
            };
        }

        private static TradingEngine.Proto.OrderInformation OrderInformation_ToProto(OrderInformation orderInformation)
        {
            return new TradingEngine.Proto.OrderInformation()
            {
                SecurityId = orderInformation.SecurityId,
                OrderId = orderInformation.OrderId,
                Username = orderInformation.Username,
            };
        }

        public static OrderActionUpdate OrderActionUpdate_FromProto(TradingEngine.Proto.OrderActionUpdate up)
        {
            return new OrderActionUpdate(UpdateType_FromProto(up.UpdateTypeCase), OrderNew_FromProto(up.OrderNewUpdate), OrderCancel_FromProto(up.OrderCancelUpdate));
        }

        private static UpdateType UpdateType_FromProto(TradingEngine.Proto.OrderActionUpdate.UpdateTypeOneofCase updateTypeCase)
        {
            return updateTypeCase switch
            {
                TradingEngine.Proto.OrderActionUpdate.UpdateTypeOneofCase.OrderCancelUpdate => UpdateType.OrderCancel,
                TradingEngine.Proto.OrderActionUpdate.UpdateTypeOneofCase.OrderNewUpdate => UpdateType.OrderNew,
                _ => throw new InvalidOperationException($"Unknown UpdateType ({updateTypeCase})"),
            };
        }

        private static OrderNew OrderNew_FromProto(TradingEngine.Proto.OrderNew orderNewUpdate)
        {
            if (orderNewUpdate == null)
                return null;
            return new OrderNew(orderNewUpdate.SendTime.ToDateTime(), OrderInformation_FromProto(orderNewUpdate.OrderInformation), 
                orderNewUpdate.IsBuy, orderNewUpdate.Price, orderNewUpdate.Quantity);
        }

        private static OrderInformation OrderInformation_FromProto(TradingEngine.Proto.OrderInformation orderInformation)
        {
            return new OrderInformation(orderInformation.Username, orderInformation.OrderId, orderInformation.SecurityId);
        }

        private static OrderCancel OrderCancel_FromProto(TradingEngine.Proto.OrderCancel orderCancelUpdate)
        {
            if (orderCancelUpdate == null)
                return null;
            return new OrderCancel(orderCancelUpdate.SendTime.ToDateTime(), 
                OrderInformation_FromProto(orderCancelUpdate.OrderInformation));
        }
    }
}
