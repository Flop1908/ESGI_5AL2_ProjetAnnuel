#import "VDMEntry.h"

@implementation VDMEntry
@synthesize contents, entryId, agreeCount, deserveCount, commentsCount,
	date,author;

int entryId;
int agreeCount;
int deserveCount;
int commentsCount;
-(void) dealloc {
	contents=nil;
    author=nil;
    date=nil;
	//[super dealloc];
}

@end
