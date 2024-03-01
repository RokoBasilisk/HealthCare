export default function GroupItem({
  params,
}: {
  params: {
    username: string;
    correctAnswer: number;
    totalCorrect: number;
  };
}) {
  return (
    <div className="row">
      <div className="col">
        {params.username}: {params.correctAnswer}/{params.totalCorrect}
      </div>
      <div className="col text-end">
        {(params.correctAnswer / params.totalCorrect) * 100}%
      </div>
    </div>
  );
}
