import { TranslatorModel } from "../types.generated";

type Props = { data?: TranslatorModel[]; loading?: boolean };

const thanslatorsTable = ({ data, loading }: Props) => {
  if (loading === true) return "Loading...";

  return (
    <table>
      <thead>
        <tr>
          <th>Id</th>
          <th>Name</th>
          <th>Hourly Rate</th>
          <th>Status</th>
          <th>Credit Card Number</th>
        </tr>
      </thead>
      <tbody>
        {data?.map(a => (
          <tr key={a.id}>
            <td>{a.id}</td>
            <td>{a.name}</td>
            <td>{a.hourlyRate}</td>
            <td>{a.status}</td>
            <td>{a.creditCardNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default thanslatorsTable;
