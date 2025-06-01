import { useState, useMemo } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../App.css";
import Large_Slot from "../Category_Slots/Large_Slot";
import LoginRegister from "../Login/Login";

const HARDCODED_CATEGORIES = [
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

const calculateGridLayout = (count) => {
  if (count <= 2) return { cols: count, rows: 1 };
  if (count <= 4) return { cols: 2, rows: 2 };
  if (count <= 6) return { cols: 3, rows: 2 };
  if (count <= 9) return { cols: 3, rows: 3 };
  return { cols: 4, rows: Math.ceil(count / 4) };
};

function Main() {
  const [categories, setCategories] = useState([HARDCODED_CATEGORIES[0]]);
  const visibleCount = categories.length;

  const addNewCategory = () => {
    if (visibleCount >= HARDCODED_CATEGORIES.length) return;
    setCategories(prev => [...prev, HARDCODED_CATEGORIES[visibleCount]]);
  };

  const { cols, rows } = useMemo(() => (
    calculateGridLayout(visibleCount)
  ), [visibleCount]);

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
            isNew={index === visibleCount - 1}
          />
        ))}
        <div className="Floating_div">
          <button
            className="Counter_Button"
            onClick={addNewCategory}
            disabled={visibleCount >= HARDCODED_CATEGORIES.length}
          >
            Show {Math.min(visibleCount + 1, HARDCODED_CATEGORIES.length)} Categories
          </button>
          <LoginRegister />
        </div>
      </div>
    </div>
  );
}

export default Main;