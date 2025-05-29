import { getColorByNumber } from "../Misc/Constants";

const Large_Slot = ({ Colour = 1, Name = '', Id = '', isNew = false }) => {
  const bgColor = getColorByNumber(Colour);
  
  return (
    <div className={`Large_Container ${isNew ? 'new-item' : ''}`}>
      <div 
        className="Content_Body" 
        style={{ 
          backgroundColor: bgColor,
        }}
      >
        <h1>{Name}, {Id}</h1>
      </div>
    </div>
  );
};

export default Large_Slot