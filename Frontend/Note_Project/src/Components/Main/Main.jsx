import { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../App.css"; 
import Large_Slot from "../Category_Slots/Large_Slot";
import LoginRegister from "../Login/Login";

function Main() {
  const Hardcoded_categories = [
    { id: 1, name: "Technology", color: 1 },
    { id: 2, name: "Science", color: 2 },
    { id: 3, name: "Arts", color: 3 },
    { id: 4, name: "Sports", color: 4 },
    { id: 5, name: "Health", color: 5 },
    { id: 6, name: "Business", color: 6 },
    { id: 7, name: "Education", color: 7 },
    { id: 8, name: "Entertainment", color: 8 },
    { id: 9, name: "Politics", color: 9 },
    { id: 10, name: "Food", color: 10 },
    { id: 11, name: "Travel", color: 11 },
    { id: 12, name: "Fashion", color: 12 },
    { id: 13, name: "Nature", color: 13 },
    { id: 14, name: "History", color: 14 },
    { id: 15, name: "Finance", color: 15 },
    { id: 16, name: "Music", color: 16 },
  ];

  const [categories, setCategories] = useState([Hardcoded_categories[0]]);
  const [visibleCount, setVisibleCount] = useState(1);

  const addNewCategory = () => {
    if (categories.length >= Hardcoded_categories.length) return;
    const nextCategory = Hardcoded_categories[categories.length];
    setCategories([...categories, nextCategory]);
    setVisibleCount(visibleCount + 1);
  };

  const getGridLayout = () => {
    switch (visibleCount) {
      case 1:
        return { cols: 1, rows: 1 };
      case 2:
        return { cols: 2, rows: 1 };
      case 3:
        return { cols: 2, rows: 2 };
      case 4:
        return { cols: 2, rows: 2 };
      case 5:
        return { cols: 3, rows: 2 };
      case 6:
        return { cols: 3, rows: 2 };
      case 7:
        return { cols: 3, rows: 3 };
      case 8:
        return { cols: 3, rows: 3 };
      case 9:
        return { cols: 3, rows: 3 };
      case 10:
        return { cols: 4, rows: 3 };
      case 11:
        return { cols: 4, rows: 3 };
      case 12:
        return { cols: 4, rows: 3 };
      case 13:
        return { cols: 4, rows: 4 };
      case 14:
        return { cols: 4, rows: 4 };
      case 15:
        return { cols: 4, rows: 4 };
      case 16:
        return { cols: 4, rows: 4 };
      default:
        return { cols: 2, rows: 2 };
    }
  };

  const { cols, rows } = getGridLayout();

  return (
    <div className="app-container">
      <div
        className="Background_container"
        style={{
          gridTemplateColumns: `repeat(${cols}, 1fr)`,
          gridTemplateRows: `repeat(${rows}, 1fr)`,
        }}
      >
        {categories.map((category, index) => (
          <Large_Slot
            key={category.id}
            Colour={category.color}
            Name={category.name}
            Id={category.id}
            isNew={index === categories.length - 1}
          />
        ))}
        <div className="Floating_div">
          <button
            className="Counter_Button"
            onClick={addNewCategory}
            disabled={categories.length >= Hardcoded_categories.length}
          >
            Show {Math.min(visibleCount + 1, Hardcoded_categories.length)}{" "}
            Categories
          </button>
          <LoginRegister/>
        </div>
      </div>
    </div>
  );
}

export default Main;
