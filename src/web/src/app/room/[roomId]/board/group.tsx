import GroupItem from "./groupItem";

interface Member {
  username: string;
  correctAnswer: number;
  totalCorrect: number;
}

export default function Group({
  params,
}: {
  params: {
    groupId: string;
    members: Array<Member>;
  };
}) {
  return (
    <div className="row justify-content-center">
      <div className="col-md-12 mb-3">
        <div
          className="card h-100"
          data-bs-toggle="collapse"
          data-bs-target={"#" + params.groupId}
        >
          <div className="card-header d-flex justify-content-between align-items-center">
            <h5 className="card-title">Group {params.groupId}</h5>
            <span className="badge bg-primary rounded-pill">
              {params.members.length} Participants
            </span>
          </div>
          <div className="card-body">
            <p className="card-text">Total Correct: 8/16</p>
            <p className="card-text">Status: Full</p>
          </div>
          <div className="card-footer">
            <div className="collapse" id={params.groupId}>
              {params.members.map((member, key) => {
                return (
                  <GroupItem
                    key={key}
                    params={{
                      username: member.username,
                      correctAnswer: member.correctAnswer,
                      totalCorrect: member.totalCorrect,
                    }}
                  />
                );
              })}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
