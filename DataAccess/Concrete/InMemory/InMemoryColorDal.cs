using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color { ColorId=1, ColorName="White" },
                new Color { ColorId=2, ColorName="Yellow" },
                new Color { ColorId=3, ColorName="Red" },
                new Color { ColorId=4, ColorName="Blue" },
                new Color { ColorId=5, ColorName="Green" },
                new Color { ColorId=6, ColorName="Orange" },
                new Color { ColorId=7, ColorName="Silver" },
                new Color { ColorId=8, ColorName="Gray" },
                new Color { ColorId=9, ColorName="Black" },
            };
        }
        public void Add(Color entity)
        {
            _colors.Add(entity);
        }

        public void Delete(Color entity)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == entity.ColorId);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colors;
        }

        public void Update(Color entity)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == entity.ColorId);
            colorToUpdate.ColorId = entity.ColorId;
            colorToUpdate.ColorName = entity.ColorName;
        }
    }
}
