import { TranslatorModel } from "../types.generated";

type Props = { data?: TranslatorModel[]; loading?: boolean };

const thanslatorsTable = ({ data, loading }: Props) => {
  if (loading === true) return "Loading...";

  return (
    <table>
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Hourly Rate</th>
        <th>Status</th>
        <th>Credit Card Number</th>
      </tr>
      {data?.map((a) => (
        <tr>
          <th>{a.id}</th>
          <th>{a.name}</th>
          <th>{a.hourlyRate}</th>
          <th>{a.status}</th>
          <th>{a.creditCardNumber}</th>
        </tr>
      ))}
    </table>
  );
};

export default thanslatorsTable;
