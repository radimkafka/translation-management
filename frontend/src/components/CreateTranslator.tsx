import { useState } from "react";
import { AddTranslatorModel, TranslatorStatusModel } from "../types.generated";
import useAddTranslatorMutation from "../hooks/useAddTranslatorMutation";

const initTranslator: AddTranslatorModel = {
  creditCardNumber: "",
  hourlyRate: 0,
  name: "",
  status: TranslatorStatusModel.Applicant,
};

const CreateTranslator = () => {
  const [newTranslator, setNewTranslator] = useState<AddTranslatorModel>(initTranslator);

  const { mutateAsync, isLoading } = useAddTranslatorMutation();
  if (isLoading) return "Loading...";

  return (
    <div>
      <h3>Add translator</h3>
      <div style={{ padding: "8px", display: "grid" }}>
        <div style={{ gridColumn: 1, gridRow: 1, textAlign: "left" }}>Name:</div>
        <div style={{ gridColumn: 2, gridRow: 1 }}>
          <input
            style={{ width: "100%" }}
            value={newTranslator.name}
            onChange={a => setNewTranslator(s => ({ ...s, name: a.target.value }))}
          />
        </div>

        <div style={{ gridColumn: 1, gridRow: 2, textAlign: "left" }}>Credit Card Number:</div>
        <div style={{ gridColumn: 2, gridRow: 2 }}>
          <input
            style={{ width: "100%" }}
            value={newTranslator.creditCardNumber}
            onChange={a => setNewTranslator(s => ({ ...s, creditCardNumber: a.target.value }))}
          />
        </div>

        <div style={{ gridColumn: 1, gridRow: 3, textAlign: "left" }}>Hourly rate:</div>
        <div style={{ gridColumn: 2, gridRow: 3 }}>
          <input
            style={{ width: "100%" }}
            value={newTranslator.hourlyRate}
            onChange={a => setNewTranslator(s => ({ ...s, hourlyRate: Number(a.target.value) }))}
            type="number"
          />
        </div>

        <div style={{ gridColumn: 1, gridRow: 4, textAlign: "left" }}>Status:</div>
        <div style={{ gridColumn: 2, gridRow: 4 }}>
          <select
            style={{ width: "100%" }}
            onChange={a => setNewTranslator(s => ({ ...s, status: a.target.value as TranslatorStatusModel }))}
          >
            <option value={TranslatorStatusModel.Applicant}>Applicant</option>
            <option value={TranslatorStatusModel.Certified}>Certified</option>
            <option value={TranslatorStatusModel.Deleted}>Deleted</option>
          </select>
        </div>

        <div style={{ gridColumnStart: 1, gridColumnEnd: 3, gridRow: 5, marginTop: "8px" }}>
          <button
            onClick={async _ => {
              await mutateAsync(newTranslator);
              setNewTranslator(initTranslator);
            }}
          >
            Add
          </button>
        </div>
      </div>
    </div>
  );
};

export default CreateTranslator;
