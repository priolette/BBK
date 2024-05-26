import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { CommentResponse } from "@/lib/server/comments";
import { User } from "lucide-react";

export function CommentCard({ comment }: { comment: CommentResponse }) {
  return (
    <Card>
      <CardHeader className="flex flex-row items-center gap-2 space-y-0">
        <Avatar className="h-8 w-8">
          <AvatarImage
            src={comment.createdBy?.picture ?? ""}
            alt={comment.createdBy?.fullName ?? ""}
          />
          <AvatarFallback>
            <User />
          </AvatarFallback>
        </Avatar>
        <span className="font-semibold">{comment.createdBy?.fullName}</span>
      </CardHeader>
      <CardContent>
        <p>{comment.text}</p>
      </CardContent>
    </Card>
  );
}
