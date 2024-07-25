using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.DataAccess.Abstract
{
    public interface IRoomRepository
    {
        List<RoomViewModel> GetAll(string IncludeProperties);

        RoomViewModel GetRoomById(int RoomId);

        void UpdateRoom(RoomViewModel roomViewModel);

        void CreateRoom(RoomViewModel roomViewModel);

        void DeleteRoom(int id);
    }
}
