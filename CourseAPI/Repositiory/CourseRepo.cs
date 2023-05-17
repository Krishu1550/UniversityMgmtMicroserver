


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


    public class CourseRepo : ICourseRepo
    {
        CourseDbContext _db;
        int ClassroomCounter = 0, i = 1;
        int classRoomLength = 5;
        int dayCounter = 1;
        int slotnum = 1;
        public CourseRepo(CourseDbContext courseDbContext)
        {
            _db = courseDbContext;
        }
        public async Task<int> CreateCourse(Course course)
        {
            if (course.NumOfClassPerWeek > 3 || course.NumOfSlot > 3)
            {
                return 1;

            }
            await  _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            while (i <= course.NumOfClassPerWeek)
            {

                Day days = await _db.Days.Where(day => day.DayNum == dayCounter).FirstOrDefaultAsync();
                days.ClassRooms = await _db.ClassRooms.Where(classroom => classroom.DayId == days.DayId).ToListAsync();
                classRoomLength = days.ClassRooms.Count();
                int classroomId = days.ClassRooms[ClassroomCounter].ClassRoomId;
                slotnum =  _db.Slots.Where(s => s.ClassRoomId == classroomId).Count() + 1;
                Course createdCourse = await _db.Courses.Where(cou => cou.CourseName == course.CourseName)
                .FirstOrDefaultAsync();

                if (await _db.Slots.Where(s => s.SlotNum == slotnum && s.ClassRoomId == classroomId)
                .FirstOrDefaultAsync() == null)
                {
                    for (int j = 0; j < course.NumOfSlot; j++)
                    {

                        if (slotnum > 5)
                        {
                            i--;
                            dayCounter--;
                            course.NumOfSlot = course.NumOfSlot - j;
                            ClassroomCounter++;
                            break;
                        }

                        Slot slot = new Slot()
                        {
                            SlotNum = slotnum,
                            CourseId = createdCourse.CourseId,
                            ClassRoomId = classroomId
                        };


                      await  _db.Slots.AddAsync(slot);
                      await  _db.SaveChangesAsync();
                        slotnum++;
                        ClassroomCounter = 0;


                    };
                    i++;
                    dayCounter++;
                }
                else
                {
                    slotnum++;
                }

                if (ClassroomCounter >= classRoomLength)
                {
                    dayCounter++;
                    ClassroomCounter = 0;

                }
                else if (dayCounter > 5)
                {


                    return 2;

                }




            }


            return 0;


        }


    


        public async Task<int>DeleteCourse(int id)
        {
            if (id == 0) { return 1; }
            var deleteCourse = await  _db.Courses.Where(c => c.CourseId == id).FirstOrDefaultAsync();
            if (deleteCourse == null)
            {

                return 2;

            }
            _db.Courses.Remove(deleteCourse);
            var deleteSlots = await  _db.Slots.Where(s => s.CourseId == deleteCourse.CourseId).ToListAsync();
            foreach (var delslot in deleteSlots)
            {
                _db.Slots.Remove(delslot);

            }
             await   _db.SaveChangesAsync();



            return 0;
        }

        public async Task <IEnumerable<Course>> GetAllCourses()
        {
            return  await _db.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses.SingleOrDefaultAsync(course => course.CourseId == id);
        }

        public async Task< bool> SavaChange()
        {
             await _db.SaveChangesAsync();
            return true;
        }

        public  async Task<int> UpdateCourse(Course course)
        {
            if(course == null) { return  1; }

           Course oldcourse=   await _db.Courses.SingleOrDefaultAsync(c=>c.CourseId==course.CourseId);
            oldcourse.CourseName= course.CourseName;
            oldcourse.NumOfClassPerWeek= course.NumOfClassPerWeek;
            oldcourse.NumOfSlot= course.NumOfSlot;
            var deleteSlots = await _db.Slots.Where(s => s.CourseId == oldcourse.CourseId).ToListAsync();
            if (deleteSlots == null)
            {
                return 2;
            }
            else
            {
                foreach (var delslot in deleteSlots)
                {
                    _db.Slots.Remove(delslot);

                }
                await   _db.SaveChangesAsync();
                while (i <= course.NumOfClassPerWeek)
                {

                    Day days =await  _db.Days.Where(day => day.DayNum == dayCounter).FirstOrDefaultAsync();
                    days.ClassRooms = await _db.ClassRooms.Where(classroom => classroom.DayId == days.DayId).ToListAsync();
                    classRoomLength = days.ClassRooms.Count();
                    int classroomId = days.ClassRooms[ClassroomCounter].ClassRoomId;
                    slotnum = _db.Slots.Where(s => s.ClassRoomId == classroomId).Count() + 1;
                    Course createdCourse = await  _db.Courses.Where(cou => cou.CourseName == course.CourseName)
                    .FirstOrDefaultAsync();

                    if (  await _db.Slots.Where(s => s.SlotNum == slotnum && s.ClassRoomId == classroomId)
                    .FirstOrDefaultAsync() == null)
                    {
                        for (int j = 0; j < course.NumOfSlot; j++)
                        {

                            if (slotnum > 5)
                            {
                                i--;
                                dayCounter--;
                                course.NumOfSlot = course.NumOfSlot - j;
                                ClassroomCounter++;
                                break;
                            }

                            Slot slot = new Slot()
                            {
                                SlotNum = slotnum,
                                CourseId = createdCourse.CourseId,
                                ClassRoomId = classroomId
                            };


                            await _db.Slots.AddAsync(slot);
                            await _db.SaveChangesAsync();
                            slotnum++;
                            ClassroomCounter = 0;


                        };
                        i++;
                        dayCounter++;
                    }
                    else
                    {
                        slotnum++;
                    }

                    if (ClassroomCounter >= classRoomLength)
                    {
                        dayCounter++;
                        ClassroomCounter = 0;

                    }
                    else if (dayCounter > 5)
                    {


                        return 3;

                    }

                }


                return 0;
            }

        }

       
    }

