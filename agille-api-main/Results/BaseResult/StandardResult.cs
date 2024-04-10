using System;
using System.Collections.Generic;

namespace Backend.Results.BaseResult
{
    public class StandardResult
    {
        public DateTime RequestTime { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        public Status Status { get; set; }
        public Content Content { get; set; }

        public StandardResult Mock()
        {
            RequestTime = DateTime.Now;
            Message = "Procedimento realizado com sucesso";
            Messages = new List<string>()
            {
                "Procedimento ",
                "realizado",
                "com",
                "sucesso"
            };
            Status = new Status().InstanceByStatusCode("200");
            Content = new Content().Mock();

            return this;
        }
    }
}
//{
//    "requestTime": new Date(),
//    "message": MESSAGE,
//    "messages": [MESSAGES],
//    "status": {
//        code: STATUS_CODE,
//        message: STATUS_MESSAGE,
//        flag: STATUS_FLAG
//    },
//    "content": {
//        data: [DATA],
//        metadata: {
//            data_size: DATA_SIZE,
//            offset: OFFSET,
//            limit: LIMIT,
//            sort_collumn: SORT_COLLUMN,
//            sort_direction: SORT_DIRECTION
//        }
//    }
//}