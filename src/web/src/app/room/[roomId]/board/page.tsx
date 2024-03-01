import { Suspense } from "react";
import Group from "./group";
interface Member {
  username: string;
  correctAnswer: number;
  totalCorrect: number;
}
export default function Page({ params }: { params: { id: string } }) {
  const array: Array<Array<Member>> = [
    [
      { username: "User 1", correctAnswer: 4, totalCorrect: 8 },
      { username: "User 2", correctAnswer: 1, totalCorrect: 8 },
      { username: "User 3", correctAnswer: 3, totalCorrect: 8 },
    ],
    [
      { username: "User 4", correctAnswer: 4, totalCorrect: 8 },
      { username: "User 5", correctAnswer: 4, totalCorrect: 8 },
    ],
  ];
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <div className="container">
        <Suspense fallback={<p>Loading Groups...</p>}>
          {array.map((members, key) => {
            return (
              <Group
                key={key}
                params={{ groupId: "group-" + key, members: members }}
              />
            );
          })}
        </Suspense>
      </div>
    </main>
  );
}
